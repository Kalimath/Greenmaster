using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Greenmaster.Core.Database.Interfaces;
using Greenmaster.Core.Examples;
using Greenmaster.Core.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database;

public class DataInitializer
{
    private readonly UserContext _dbContext;
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public DataInitializer(UserContext dbContext, IApplicationDbContext applicationDbContext, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _dbContext = dbContext;
        _applicationDbContext = applicationDbContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> SeedData()
    {
        //stop if data is already present...
        if (_dbContext.Users.Any() || _dbContext.Roles.Any() || _dbContext.RoleClaims.Any()) return true;
            
        await SeedDummyDataAsync();
        await SeedRolesAsync();
        await SeedUsersAsync();
        return true;
    }
    private async Task SeedDummyDataAsync()
    {
        await _applicationDbContext.Species.AddRangeAsync(SpecieExamples.GetAll());
        await _applicationDbContext.MaterialTypes.AddRangeAsync(MaterialTypeExamples.GetAll());
        await _applicationDbContext.PlantTypes.AddRangeAsync(ObjectTypeExamples.GetAllPlantTypes());
        await _applicationDbContext.StructureTypes.AddRangeAsync(ObjectTypeExamples.GetAllStructureTypes());
        await _applicationDbContext.GardenStyles.AddRangeAsync(GardenStyleExamples.GetAll());
        await _applicationDbContext.Renderings.AddRangeAsync(RenderingExamples.GetAll());
        await _applicationDbContext.Placeables.AddRangeAsync(PlaceableExamples.GetAll());

        await _dbContext.SaveChangesAsync();
    }
        
    #region Roles
    private async Task SeedRolesAsync()
    {
        await _roleManager.CreateAsync(new Role(Roles.Admin.ToString()));
        await _roleManager.CreateAsync(new Role(Roles.Limited.ToString()));
        await SeedClaimsForAdmin();
    }
    private async Task SeedClaimsForAdmin()
    {
        var adminRole = await _roleManager.FindByNameAsync(Roles.Admin.ToString());
        foreach (var module in Permission.AllModules)
        {
            await AddPermissionClaim(adminRole, module);
        }
    }
    private async Task AddPermissionClaim(Role role, string module)
    {
        var allClaims = await _roleManager.GetClaimsAsync(role);
        var allPermissions = Permission.GenerateAllPermissionsForModule(module);
        foreach (var permission in allPermissions.Where(permission => !allClaims.Any(a => a.Type == "Permission" && a.Value == permission)))
        {
            await _roleManager.AddClaimAsync(role, new Claim("Permission", permission));
        }
    }
    #endregion

    #region Users
    private async Task SeedUsersAsync() 
    {
        var defaultUser = new User("limited", "user", "limited.user@greenmaster.eu", "0000000000000")
        {
            EmailConfirmed = true,
        };
        defaultUser.PasswordSalt = CreateSalt();
        defaultUser.PasswordHash = GenerateHash("P@ssword123", defaultUser.PasswordSalt);
        await _userManager.CreateAsync(defaultUser);
        await _userManager.AddToRoleAsync(defaultUser, Roles.Limited.ToString());

        var mathieu = new User("Mathieu", "Broeckhoven", "mathieu.broeckhoven@greenmaster.eu", "+32472067508")
        {
            EmailConfirmed = true,
        };
        mathieu.PasswordSalt = CreateSalt();
        mathieu.PasswordHash = GenerateHash("P@ssword123", mathieu.PasswordSalt);
        await _userManager.CreateAsync(mathieu);
        await _userManager.AddToRoleAsync(mathieu, Roles.Admin.ToString());

        var karyna = new User("Karyna", "Krupianskaya", "Karyna.Krupianskaya@greenmaster.eu", "+32123456789")
        {
            EmailConfirmed = true,
        };
        karyna.PasswordSalt = CreateSalt();
        karyna.PasswordHash = GenerateHash("P@ssword123", karyna.PasswordSalt);
        await _userManager.CreateAsync(karyna);
        await _userManager.AddToRoleAsync(karyna, Roles.Admin.ToString());
    }

    //see AuthenticationHelper
    private static string CreateSalt()
    {
        //Generate a cryptographic random number.
        var rng = RandomNumberGenerator.Create();
        var buff = new byte[15];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }
    //see AuthenticationHelper
    private static string GenerateHash(string input, string salt)
    {
        var bytes = Encoding.UTF8.GetBytes(input + salt);
        var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
    #endregion
       
}