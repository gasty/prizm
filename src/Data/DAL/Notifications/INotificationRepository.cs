﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prizm.Domain.Entity;

namespace Prizm.Data.DAL.Notifications
{
    public interface INotificationRepository : IRepository<Guid, Item>
    {
    }
}
