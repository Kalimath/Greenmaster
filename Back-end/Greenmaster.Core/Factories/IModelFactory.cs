namespace Greenmaster.Core.Factories;

public interface IModelFactory<T1, T2> where T1 : class where T2 : class
{
    public Task<T1> Create(T2 viewModel);

    public T2 ToViewModel(T1 model);
}