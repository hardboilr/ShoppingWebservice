using System.Collections;
using System.Collections.Generic;
using ShoppingWebservice.ErrorHandling;

namespace ShoppingWebservice.Shared.DTOs {

    public class ResponseDto {

        public string Message { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public IList Data { get; set; }
    }
}
