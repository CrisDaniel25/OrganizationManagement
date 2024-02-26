namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class FormsAccessDto
    {
        public object? Form { get; set; }
        public List<AccessTypeDto>? AccessTypes { get; set; }
    }
}
