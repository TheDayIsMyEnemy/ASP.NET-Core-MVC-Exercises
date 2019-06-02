using AutoMapper;

namespace BookShop.Common.Mappings
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}