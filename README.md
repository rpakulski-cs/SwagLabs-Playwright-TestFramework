# SwagLabs-Playwright-TestFramework

Automated E2E testing framework for SwagLabs using C#, Playwright, and MSTest.

## 🏗️ Architecture
This solution follows the Separation of Concerns (SoC) principle to ensure scalability and maintainability:
* **`SwagLabs.Pages`**: A Class Library containing Page Object Models (POM). It has no knowledge of the testing framework.
* **`SwagLabs.UITests`**: An MSTest project responsible for test execution, data management, and assertions.

## 🚀 Environment Setup 

Follow these commands to recreate this project structure and install all necessary dependencies via .NET CLI.

### 1. Create Solution and Projects
```bash
# Create the Solution file
dotnet new sln -n swaglabs-playwright-testframework

# Create the Test Project and Page Objects Project
dotnet new mstest -n SwagLabs.UITests
dotnet new classlib -n SwagLabs.Pages

# Add both projects to the Solution
dotnet sln add SwagLabs.UITests/SwagLabs.UITests.csproj
dotnet sln add SwagLabs.Pages/SwagLabs.Pages.csproj

# Add project reference (Tests must depend on Pages)
dotnet add SwagLabs.UITests/SwagLabs.UITests.csproj reference SwagLabs.Pages/SwagLabs.Pages.csproj
```

### 2. Install Dependencies
```bash
# Add Playwright packages to respective projects
dotnet add SwagLabs.UITests package Microsoft.Playwright.MSTest
dotnet add SwagLabs.Pages package Microsoft.Playwright

# Build the solution to generate Playwright binaries in the bin/ folder
dotnet build
```

### 3. Install Playwright Browsers
```bash
# Install Playwright CLI tool globally (only needed once per machine)
dotnet tool install --global Microsoft.Playwright.CLI

# Install the actual browsers (Chromium, Firefox, WebKit)
# On macOS (if .dotnet/tools is not in your PATH):
~/.dotnet/tools/playwright install

# On Windows (or macOS with properly configured PATH):
playwright install
```

***
