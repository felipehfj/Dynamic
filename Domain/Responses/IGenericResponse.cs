using System;

namespace Domain.Responses
{
    public interface IGenericResponse
    {
        object Data { get; set; }
        string ErrorMessage { get; set; }
        Guid Id { get; set; }
        bool Success { get; set; }
    }
}