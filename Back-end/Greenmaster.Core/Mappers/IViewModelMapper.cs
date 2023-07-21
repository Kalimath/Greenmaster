namespace Greenmaster.Core.Mappers;

public interface IViewModelMapper<T1, T2> where T1 : class where T2 : class
{
    public Task<T1> ToModel(T2 viewModel);

    public T2 ToViewModel(T1 model);
}