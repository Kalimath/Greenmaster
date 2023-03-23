using Greenmaster_ASP.Helpers;

namespace Greenmaster_ASP.Models.Examples{
public static class Base64Examples
  {
      private const string PathImageSpecie = @"C:\Users\mathi\RiderProjects\Greenmaster_ASP\Greenmaster_ASP\wwwroot\media\img\Arboretum\Trees0091_350.jpg";
      private const string PathImageRendering = @"C:\Users\mathi\RiderProjects\Greenmaster_ASP\Greenmaster_ASP\wwwroot\media\clipart\treetops\top_tree_2-250px.png";
      
      public static string ImageSpecie = FileConverter.ToBase64(PathImageSpecie);
      public static string ImageRendering = FileConverter.ToBase64(PathImageRendering);
  }
 }