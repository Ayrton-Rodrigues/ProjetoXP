using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Api.Controller
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly List<string>? _temNotificacao = new();

        protected ActionResult CustomResponse(ModelStateDictionary model)
        {
            if (!model.IsValid) ObterErrors(model);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(object? obj = null)
        {

            if (_temNotificacao?.Count == 0)
            {
                return Ok(new
                {
                    success = true,
                    data = obj
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _temNotificacao
            });

        }


        private void ObterErrors(ModelStateDictionary model)
        {
            var errors = model.Values.SelectMany(x => x.Errors);
            if (errors.Count() > 0)
            {
                foreach (var error in errors)
                {
                    var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                    _temNotificacao?.Add(errorMessage);
                }

            }

        }
    }
}
