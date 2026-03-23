using Microsoft.Playwright;

namespace SwagLabs.Pages;

public class LoginPage
{
    private readonly IPage _page;

    private readonly ILocator _usernameInput;
    private readonly ILocator _passwordInput;
    private readonly ILocator _loginButton;

    public LoginPage(IPage page)
    {
        _page = page;
        
        _usernameInput = _page.Locator("[data-test='username']");
        _passwordInput = _page.Locator("[data-test='password']");
        _loginButton = _page.GetByRole(AriaRole.Button, new () { Name = "Login" } );
    }

    public async Task LoginAsync(string username, string password)
    {
        await _usernameInput.FillAsync(username);
        await _passwordInput.FillAsync(password);
        await _loginButton.ClickAsync();
    }

    public async Task OpenAsync()
        => await _page.GotoAsync("https://www.saucedemo.com/");
        
}