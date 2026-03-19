using Microsoft.Playwright.MSTest;
using SwagLabs.Pages;

namespace SwagLabs.UITests;

[TestClass]
public class LoginTests : PageTest
{
    [TestMethod]
    [DataRow("standard_user", "secret_sauce")]
    public async Task StandardUser_CanLogin_Successfully(string username, string password)
    {
        var loginPage = new LoginPage(Page);

        await loginPage.OpenAsync();
        await loginPage.LoginAsync(username, password);

        await Expect(Page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex(".*inventory.*"));
    }
}