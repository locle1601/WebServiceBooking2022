
using FluentValidation;

namespace WebServiceBooking.ViewModels.Contents
{
   public class MyHotelRestaurantCreateRequestValidator : AbstractValidator<MyHotelRestaurantCreateRequest>
    {
      public MyHotelRestaurantCreateRequestValidator()
        {
            RuleFor(x => x.HotelRestaurantName).NotEmpty().WithMessage("Hotel/Restaurant Name is required");
        }
    }
}
