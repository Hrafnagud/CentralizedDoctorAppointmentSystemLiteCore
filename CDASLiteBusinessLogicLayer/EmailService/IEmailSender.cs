﻿using CDASLiteEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.EmailService
{
    public interface IEmailSender
    {
        Task SendAsnc(EmailMessage message);
    }
}