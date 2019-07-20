using BP.Domain.Shared.Attributes;
using BP.Domain.Shared.Notification;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BP.API.Shared
{
    [TypeFilter(typeof(ValidateNotationAttribute), Order = 0)]
    public class SharedController : Controller
    {
        protected readonly INotificationDomainService _notifications;

        protected SharedController(INotificationDomainService notifications)
        {
            _notifications = notifications;
        }

        protected IActionResult ResponseData(object result, HttpReturn httpReturn)
        {
            if (_notifications.IsValid())
            {
                if (httpReturn == HttpReturn.Created)
                    return Created("", result);
                else if (httpReturn == HttpReturn.OK)
                    return Ok(result);
                else if (httpReturn == HttpReturn.NoContent)
                    return NoContent();
                else if (httpReturn == HttpReturn.Accepted)
                    return Accepted(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, _notifications.Notifications);
            }

            return Ok(result);
        }


    }
}
