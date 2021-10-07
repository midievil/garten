using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Garten.Common.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zing.Auth.Api.Controllers.Base
{
    [ApiController]
    [Route("[area]/api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected Guid? SessionId
            => Guid.TryParse(User.FindFirstValue(ClaimTypes.Sid), out var sessionId)
                ? sessionId : null;

        /// <summary>
        /// Current user id
        /// </summary>
        protected Guid? CurrentUserId
            => Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId)
                ? userId : null;

        /// <summary>
        /// Выполнить указанный метод и обернуть результат выполнения в ответ для API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected async Task<ActionResult<T>> ProcessResultAsync<T>(Func<Task<T>> func)
        {
            try
            {
                var response = await func();
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (FormatException e)
            {
                return BadRequest(new { Error = e.Message });
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                //_logger.LogError(e, $"Error in controller. \nUserId: {CurrentUserId}\nRole: {CurrentRole}\nUrl: {Request.QueryString} \nCorrelationId: {correlationId}");
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Выполнить указанный метод и обернуть результат выполнения в ответ для API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected async Task<ActionResult> ProcessResultAsync(Func<Task> func)
        {
            try
            {
                await func();
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (FormatException e)
            {
                return BadRequest(new { Error = e.Message });
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                //_logger.LogError(e, $"Error in controller. \nUserId: {CurrentUserId}\nRole: {CurrentRole}\nUrl: {Request.QueryString} \nCorrelationId: {correlationId}");
                return StatusCode(500, new { e.Message });
            }
        }
    }
}