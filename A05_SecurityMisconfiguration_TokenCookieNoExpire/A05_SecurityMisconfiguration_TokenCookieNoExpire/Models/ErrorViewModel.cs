namespace A05_SecurityMisconfiguration_TokenCookieNoExpire.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
