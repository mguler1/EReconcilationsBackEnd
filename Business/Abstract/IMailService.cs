﻿using Core.Utilities.Results.Abstarct;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMailService
    {
        IResult SendMail(SendMailDto sendMailDto);
    }
}
