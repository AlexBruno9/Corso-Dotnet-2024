using Microsoft.AspNetCore.Mvc.RazorPages;

public class ErrorModel : PageModel
{
    public string Message { get; set; }
    public void OnGet(string message)
    {
        Message = message;
    }
}