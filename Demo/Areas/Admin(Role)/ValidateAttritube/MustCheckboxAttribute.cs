﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas
{
    // http://www.dotnet-tricks.com/Tutorial/mvc/H1VF301212-MVC4-Registration-form-with-Client-and-Server-Side-Validation.html
    public class MustBeTrueAttribute : ValidationAttribute, IClientValidatable // IClientValidatable for client side Validation
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
        // Implement IClientValidatable for client side Validation
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "checkbox", ErrorMessage = this.ErrorMessage } };
        }
    }
}