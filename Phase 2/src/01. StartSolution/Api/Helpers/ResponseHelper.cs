using Api.Controllers;
namespace Api.Helpers;
public static class ResponseHelper
{
	public static ActionResult ResponseOutcome<T>(Result<T> result, ApiController controller)
	{
		if (result.Data == null)
		{
			return controller.NotFound(Common.Models.Result.Failure($"{typeof(T).Name.Replace("Model", string.Empty)} not found"));
		}

		if (!result.Succeeded)
		{
			return controller.BadRequest(result);
		}

		return controller.Ok(result);
	}

	public static ActionResult ResponseOutcome<T>(Common.Models.ListResult<T> result, ApiController controller)
	{
		if (!result.Succeeded)
		{
			return controller.BadRequest(result);
		}

		return controller.Ok(result);
	}

	public static ActionResult ResponseOutcome(Common.Models.Result result, ApiController controller)
	{
		if (!result.Succeeded)
		{
			return controller.BadRequest(result);
		}

		return controller.Ok(result);
	}
}