﻿using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace DesignByContract.Domain.Contracts.ValueObjects
{
    public class EmailValidation<T> : Specification<T>
    {
        public const int AddressMinLength = 3;
        public const int AddressMaxLength = 255;
        public const bool AddressRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var email = candidate as Email;

            if (string.IsNullOrEmpty(email?.Address))
                email?.ErrorList.Add(
                    new ErrorItemDetail("O endereço do E-Mail é requerido.",
                                        new Critical(),
                                        email.FieldName));

            if ((email?.Address ?? "").Length < AddressMinLength)
                email?.ErrorList.Add(
                    new ErrorItemDetail("Email não atende o limite mínimo de caracteres",
                                        new Critical(),
                                        email.FieldName));

            if ((email?.Address ?? "").Length > AddressMaxLength)
                email?.ErrorList.Add(
                    new ErrorItemDetail("Email excedeu o limite máximo de caracteres",
                                        new Critical(),
                                        email.FieldName));

            const string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            if (!Regex.IsMatch(email?.Address ?? "", emailPattern))
                email?.ErrorList.Add(
                    new ErrorItemDetail("Formato de e-mail inválido",
                                        new Critical(),
                                        email.FieldName));

            return !email?.ErrorList.HasCriticals() ?? false;
        }
    }
}