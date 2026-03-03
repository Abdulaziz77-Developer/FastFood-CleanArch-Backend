using AutoMapper;
using FastFoodApp.Core.Entities;
using FastFoodApp.Application.DTOs.FoodDTO;
using FastFoodApp.Application.DTOs.CategoryDTO;
using FastFoodApp.Application.DTOs.UserDTO;
using FastFoodApp.Application.DTOs.OrderDTO;
using FastFoodApp.Application.DTOs.CustomerDTO;
using FastFoodApp.Application.DTOs.SupplierDTO;
using FastFoodApp.Application.DTOs.OrderItemDTO;

namespace FastFoodApp.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // === МАППИНГ ДЛЯ ЧТЕНИЯ (Read) ===
        // Food -> FoodReadDto (подтягиваем имена из связей)
        CreateMap<Food, FoodReadDto>()
            .ConstructUsing(src => new FoodReadDto(
                src.Id,
                src.Name,
                src.Description,
                src.Price,
                src.ImageUrl,
                src.IsAvailable,
                src.CategoryId,
                src.Category != null ? src.Category.Name : "Unknown",
                src.SupplierId,
                src.Supplier != null ? src.Supplier.RestaurantName : string.Empty
            ));

        // User & Customer -> CustomerReadDto
        CreateMap<Customer, CustomerReadDto>()
            .ForMember(d => d.FullName, o => o.MapFrom(s => s.User != null ? s.User.FullName : string.Empty))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.User != null ? s.User.Email : string.Empty));

        CreateMap<Category, CategoryReadDto>();
        CreateMap<Supplier, SupplierReadDto>();
        CreateMap<User, UserReadDto>();

        // Order & Items
        CreateMap<Order, OrderReadDto>();
        CreateMap<OrderItem, OrderItemReadDto>()
            .ForMember(d => d.FoodName, o => o.MapFrom(s => s.Food != null ? s.Food.Name : string.Empty))
            .ForMember(d => d.FoodImageUrl, o => o.MapFrom(s => s.Food != null ? s.Food.ImageUrl : string.Empty))
            .ForMember(d => d.SubTotal, o => o.MapFrom(s => s.Price * s.Quantity));


        // === МАППИНГ ДЛЯ СОЗДАНИЯ (Create) ===
        CreateMap<FoodCreateDto, Food>();
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<UserRegisterDto, User>()
            .ForMember(d => d.PasswordHash, o => o.Ignore()); // Пароль хешируем вручную в сервисе
        CreateMap<SupplierCreateDto, Supplier>();
        CreateMap<OrderCreateDto, Order>()
            .ForMember(d => d.TotalAmount, o => o.MapFrom(s => s.TotalPrice));
        CreateMap<OrderItemCreateDto, OrderItem>()
            .ForMember(d => d.Price, o => o.MapFrom(s => s.PricePerUnit));


        // === МАППИНГ ДЛЯ ОБНОВЛЕНИЯ (Update) ===
        CreateMap<FoodUpdateDto, Food>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcValue) => srcValue != null));
        
        CreateMap<UserUpdateDto, User>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<CustomerUpdateDto, Customer>();
        CreateMap<SupplierUpdateDto, Supplier>();
        CreateMap<OrderStatusUpdateDto, Order>();
    }
}