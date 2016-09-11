
using System;
using ShoppingWebservice.Shared.ErrorHandling;

namespace ShoppingWebservice.Shared.DTOs {

    public class ErrorDto {

        public string ErrorMsg { get; set; }
        public string ErrorWhen { get; set; }
        public ErrorType ErrorType { get; set; }
        public Type ClassType { get; set; }
    }
}