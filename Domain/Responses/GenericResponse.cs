using System;

namespace Domain.Responses
{
    public class GenericResponse : IGenericResponse
    {
        public GenericResponse()
        {
            Id = Guid.NewGuid();
            Success = true;
            ErrorMessage = string.Empty;
            Data = null;
        }

        public GenericResponse(bool success, string errorMessage = "", object data = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
