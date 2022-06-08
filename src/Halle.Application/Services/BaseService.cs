using FluentValidation;
using FluentValidation.Results;
using Halle.Application.Interfaces;
using Halle.Application.Notifications;
using Halle.Business.Entities;

namespace Halle.Application.Services
{
    public abstract class BaseService
    {
        private readonly INotification _notification;

        public BaseService(INotification notification) =>
            _notification = notification;

        protected void Notify(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message) =>
            _notification.Handle(new Notification(message));

        protected bool ValidateModel<TV, TE>(TV validate, TE model) where TV : AbstractValidator<TE>
        {
            var validator = validate.Validate(model);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
