# BirthdayMarket Application - Comprehensive Presentation Guide

This document is designed to help you confidently present and explain the BirthdayMarket application to technical implementers.

---

## SECTION 1: EXECUTIVE SUMMARY

### What is BirthdayMarket?

BirthdayMarket is an interactive web application designed to make birthday celebrations special for children in social services programs (such as foster care). The app provides a guided, gamified shopping experience where children can select their own birthday gifts within a points-based budget.

### The Core Concept

- Children start with **500 points** (like a virtual gift card)
- They navigate through different product categories selecting items
- A friendly animated mascot named **"Mr. B-Day"** (a cartoon cake character) guides them
- The experience ends with a celebration screen and order confirmation

### Who is this for?

- **Primary Users**: Children in foster care or social services programs
- **Administrators**: Social workers or agency staff who facilitate the experience
- **Purpose**: Make birthdays feel special and give children choice in their gifts

---

## SECTION 2: THE USER JOURNEY (Step-by-Step)

Here's exactly what a child experiences when using the app:

### Step 1: Welcome Screen
- Child sees "Welcome to Birthday Market"
- They click a big "START" button to begin
- **Purpose**: Simple, inviting entry point

### Step 2: Meet Mr. B-Day (Introduction)
- An animated cake character introduces himself
- Audio plays explaining what they can do
- Floating icons show the categories available
- Child clicks "Start Shopping" to proceed
- **Purpose**: Set expectations and create excitement

### Step 3: Birthday Cards (10 points)
- Child sees 6 different birthday card options
- They select ONE card by clicking on it
- 10 points are deducted from their balance
- **Required**: Must select a card to continue

### Step 4: Books (15-25 points)
- Books are organized by reading level (3 tiers):
  - **Picture Books** (ages 0-5): 15 points
  - **Chapter Books** (ages 6-10): 20 points
  - **Teen Reads** (ages 11+): 25 points
- Child selects ONE book
- **Required**: Must select a book to continue

### Step 5: Sweet Treats (20-50 points)
- 15 different dessert options including:
  - Cookies (various types): 20-25 points
  - Cakes with different frostings: 35-40 points
  - Gift cards for allergy concerns: 50 points
- **IMPORTANT**: Includes allergen warning for wheat, gluten, eggs, peanuts, tree nuts, and milk
- Child selects ONE treat
- **Required**: Must select a treat to continue

### Step 6: Customization (FREE - 0 points)
- Child can optionally add:
  - Their name (text input)
  - Up to 3 decoration colors
- **Optional**: Can skip without penalty

### Step 7: Gifts (50-100 points each)
- Age-appropriate gift sets organized by tier:
  - **Early Childhood (0-6)**: 50 points each
  - **Youth (5-12)**: 75 points
  - **Teens (11-18)**: 100 points
- **UNIQUE**: Can select MULTIPLE gifts if points allow
- **Required**: Must select at least one gift

### Step 8: Survey (3 questions)
- Feedback questions about their experience:
  1. "How was your experience?"
  2. "How did you feel during the experience?"
  3. "What do you think about Mr. B-Day?"
- **Required**: Must answer all 3 to proceed

### Step 9: Congratulations!
- Celebration screen with confetti and balloons
- Shows points used and remaining
- Message: "YOUR BIRTHDAY MATTERS"
- "Start Over" button to reset

---

## SECTION 3: THE POINTS SYSTEM (How the Budget Works)

### Basic Rules

| Rule | Description |
|------|-------------|
| Starting Points | 500 points |
| Maximum Points | Cannot exceed 500 |
| Minimum Points | Cannot go below 0 |

### Point Costs by Category

| Category | Cost Range | Selection Type |
|----------|------------|----------------|
| Birthday Card | 10 points | Single selection |
| Book | 15-25 points | Single selection |
| Sweet Treat | 20-50 points | Single selection |
| Customization | FREE | Optional |
| Gifts | 50-100 points each | Multiple allowed |

### Minimum Spend Example
If a child picks the cheapest option in each required category:
- Card: 10 points
- Book: 15 points
- Treat: 20 points
- Gift: 50 points
- **Total minimum**: 95 points (leaving 405 for more gifts)

### Maximum Spend Example
If a child picks expensive options:
- Card: 10 points
- Book: 25 points
- Treat: 50 points
- Gift: 100 points
- **Total**: 185 points (can still add 3 more 100-point gifts)

### How Refunds Work
- If a child changes their selection, points are automatically refunded
- If they go back to a previous page, their selection is cancelled and refunded
- The system prevents overspending - you cannot select something if you don't have enough points

---

## SECTION 4: TECHNICAL ARCHITECTURE (For Developers)

### Technology Stack

| Component | Technology |
|-----------|------------|
| Framework | ASP.NET Core 8.0 |
| UI Framework | Blazor Server |
| Language | C# with Razor markup |
| Styling | CSS3 with animations |
| Database | None (in-memory only) |

### What "Blazor Server" Means
- The app runs on a server, not in the browser
- User interactions are sent to the server in real-time
- The server sends back updated HTML
- Uses SignalR (WebSocket technology) for live connection
- **Benefit**: Fast, interactive experience without page reloads

### Project Structure

```
BirthdayMarket/
├── Program.cs              # App startup configuration
├── App.razor               # Main routing component
├── Pages/                  # All the screens users see
│   ├── Index.razor         # Welcome page
│   ├── Intro.razor         # Mr. B-Day introduction
│   ├── BirthdayCards.razor # Card selection
│   ├── Books.razor         # Book selection
│   ├── SweetTreats.razor   # Treat selection
│   ├── Customized.razor    # Name/color customization
│   ├── Gifts.razor         # Gift selection
│   ├── Survey.razor        # Feedback questions
│   └── Congratulations.razor # Celebration page
├── Components/             # Reusable UI pieces
│   ├── ChatBubble.razor    # Mr. B-Day mascot
│   └── PageHeader.razor    # Title headers
├── Services/               # Business logic
│   └── PointsService.cs    # Points management
├── Shared/                 # Layout templates
│   └── MainLayout.razor    # Main page layout
└── wwwroot/                # Static files
    ├── css/                # Stylesheets
    ├── images/             # Pictures
    └── audio/              # Sound files
```

### Key Files Explained

**Program.cs** - The starting point
- Configures the web server
- Registers the PointsService
- Sets up routing

**PointsService.cs** - The brain of the points system
- Tracks current points balance
- Manages selections by category
- Handles refunds automatically
- Notifies the UI when points change

**MainLayout.razor** - The consistent wrapper
- Shows the points badge in the top-right corner
- Wraps all pages in consistent styling

---

## SECTION 5: COMMON QUESTIONS & ANSWERS

### General Questions

**Q: Is this a real online store? Do children actually buy things?**
> No, this is a selection tool. Children make their choices within the app, but the actual order fulfillment is handled separately by the agency. The app generates a "wish list" that staff then process.

**Q: Why 500 points instead of dollars?**
> Points create a positive, gamified experience. Children don't feel limited by money - they're "spending points" which feels more like a game. It also abstracts the actual costs from the experience.

**Q: What happens to the selections after a child finishes?**
> Currently, selections are shown on the Congratulations page but are NOT saved to a database. The app tells children to "contact your agency" for order fulfillment. If you need to save data, database integration would need to be added.

**Q: Can a child save their progress and come back later?**
> No. The app is session-based - if you refresh the page or close the browser, all progress is lost. It's designed for a single sitting experience.

### Technical Questions

**Q: What database does this use?**
> None currently. All data is stored in memory (RAM) during the session. When the browser closes, data is gone. To persist data, you would need to add a database like SQL Server, PostgreSQL, or even a simple file-based storage.

**Q: Can this work offline?**
> No. Blazor Server requires a constant internet connection to the server. If the connection drops, the app stops working until reconnected.

**Q: Is this mobile-friendly?**
> Yes, the CSS uses responsive design. It will work on tablets and phones, though it was primarily designed for desktop/laptop screens.

**Q: How do I add new products?**
> Products are hardcoded in each page's Razor file. To add new books, treats, or gifts, you edit the corresponding `.razor` file and add items to the list. No admin interface exists currently.

**Q: Can I change the point values?**
> Yes. Point values are defined in each page's source code. For example, in `Books.razor`, each book tier has a `Points` property that can be changed.

**Q: How does Mr. B-Day work?**
> Mr. B-Day is a CSS-animated character (no image file). The character is drawn entirely with CSS shapes and animations - eyes blink, arms wave, candles flicker. This is in the `ChatBubble.razor` component.

**Q: Where are the audio files?**
> Audio files are in `wwwroot/audio/`. Each page has an associated MP3 file that auto-plays when the page loads.

### Integration Questions

**Q: How would we connect this to our existing system?**
> You would need to:
> 1. Add a database context (Entity Framework Core recommended)
> 2. Create database models for orders, children, selections
> 3. Modify the Congratulations page to save orders
> 4. Potentially add authentication for staff

**Q: Can we add user accounts/login?**
> Not currently built in, but ASP.NET Core has built-in authentication. You could add Identity for staff logins or a simpler child identification system.

**Q: Can we change the branding/colors?**
> Yes. Styling is in CSS within each component. The main colors are:
> - Pink/red gradients for headers and buttons
> - Pastel colors for backgrounds
> - The color scheme can be modified in the CSS sections

---

## SECTION 6: FEATURE DEEP DIVES

### The Mr. B-Day Mascot

Mr. B-Day is the friendly guide throughout the app. Here's how he works:

**Visual Design (all CSS, no images):**
- A round cake body with frosting
- 3 candles on top with flickering flames
- Blinking eyes that look around
- A smiling mouth
- Waving arms and jumping legs
- Sparkles around him for celebration effect

**Speech Bubbles:**
- Each page has a message from Mr. B-Day
- Messages explain what the child should do
- Audio accompanies the text

**Technical Note:** If someone asks how this was made - it's entirely CSS animations. No JavaScript, no image files for the mascot itself.

### The Allergen Warning System

On the Sweet Treats page, there's a prominent warning box:

> "Please be advised that items in this store may contain wheat, gluten, eggs, peanuts, tree nuts, and milk. If you have any of these allergies, please consider the gift card option."

**Why this matters:**
- Protects children with food allergies
- Provides a gift card alternative (50 points)
- Clearly visible before selection

### The Points Badge

In the top-right corner of every page, there's a persistent badge showing:
- "Points Remaining: X / 500"
- Updates in real-time as selections change
- Uses event system to stay synchronized

### Survey Feedback

The survey collects 3 pieces of feedback:

1. **Experience Quality**: Amazing / Good / Fair / Needs Improvement
2. **Emotional State**: Excited / Happy / Calm / Confused / Overwhelmed
3. **Mascot Opinion**: Fun / Helpful / Needs Development

**Note**: Currently, survey responses are NOT saved anywhere. To use this data, database integration would be needed.

### Celebration Effects

The Congratulations page features:
- 20 pieces of animated confetti (CSS animation)
- 6 floating balloons (CSS animation)
- Points summary display
- Inspiring message: "YOUR BIRTHDAY MATTERS"

---

## SECTION 7: WHAT'S NOT INCLUDED (Potential Enhancements)

Current limitations that someone might ask about:

| Feature | Current State | What Would Be Needed |
|---------|---------------|---------------------|
| Data Persistence | No database | Add Entity Framework + database |
| User Accounts | No login | Add ASP.NET Identity |
| Admin Dashboard | None | Build new pages for product management |
| Order Processing | Manual/external | Build order management system |
| Reporting | None | Add database + reporting pages |
| Multi-language | English only | Add localization resources |
| Print Summary | None | Add print-friendly view |
| Email Confirmation | None | Add email service integration |

---

## SECTION 8: QUICK REFERENCE CARD

### URLs/Routes
| Page | URL Path |
|------|----------|
| Welcome | `/` |
| Introduction | `/intro` |
| Birthday Cards | `/birthday-cards` |
| Books | `/books` |
| Sweet Treats | `/sweet-treats` |
| Customization | `/customized` |
| Gifts | `/gifts` |
| Survey | `/survey` |
| Congratulations | `/congratulations` |

### Key Files to Know
| Purpose | File |
|---------|------|
| App startup | `Program.cs` |
| Points logic | `Services/PointsService.cs` |
| Main layout | `Shared/MainLayout.razor` |
| Mascot component | `Components/ChatBubble.razor` |

### Required vs Optional
| Step | Required? |
|------|-----------|
| Select birthday card | YES |
| Select book | YES |
| Select treat | YES |
| Add name/colors | NO |
| Select gift(s) | YES |
| Complete survey | YES |

---

## SECTION 9: TALKING POINTS FOR YOUR PRESENTATION

### Opening Statement
"BirthdayMarket is an interactive web application that lets children in our programs select their own birthday gifts through a fun, guided experience with a 500-point budget system."

### Key Selling Points
1. **Child-Centered**: Kids have agency in choosing their gifts
2. **Gamified**: Points system makes it feel like a game, not shopping
3. **Guided Experience**: Mr. B-Day mascot walks them through each step
4. **Budget Awareness**: Teaches resource allocation in a fun way
5. **Accessible**: Audio narration and clear visual design
6. **Safe**: Allergen warnings protect children with dietary restrictions

### For Technical Stakeholders
"The application is built on ASP.NET Core 8 with Blazor Server, providing a real-time interactive experience. The architecture is clean and maintainable with clear separation between pages, components, and services. It's ready for database integration when needed."

### For Non-Technical Stakeholders
"Think of it as a virtual birthday store just for our kids. They click through screens, pick out what they want, and at the end we get a list of their choices. It's colorful, fun, and makes them feel special."

---

## SECTION 10: GLOSSARY OF TECHNICAL TERMS

| Term | Simple Explanation |
|------|-------------------|
| Blazor | Microsoft's technology for building interactive websites with C# |
| Razor | A way to mix HTML with C# code in web pages |
| Component | A reusable piece of a webpage (like Mr. B-Day or the header) |
| Service | Code that handles logic (like tracking points) |
| Singleton | One shared copy of something used everywhere in the app |
| SignalR | Technology that keeps the browser connected to the server |
| CSS | The code that controls colors, fonts, and animations |
| Route | The URL path that takes you to a specific page |
| Session | One visit to the website (lost when you close browser) |
| In-Memory | Stored in computer's temporary memory (not saved permanently) |

---

---

## SECTION 11: HOW THE APP WAS BUILT (Current State Deep Dive)

This section explains how each part of the application was created and what each portion does in detail.

### The Foundation: Program.cs

This is where the application starts. Think of it as the "ignition key" that starts everything.

```csharp
var builder = WebApplication.CreateBuilder(args);

// These lines add capabilities to the app:
builder.Services.AddRazorPages();          // Enables web pages
builder.Services.AddServerSideBlazor();     // Enables real-time interactivity
builder.Services.AddSingleton<PointsService>(); // Creates ONE points tracker for everyone

var app = builder.Build();

// These lines configure how the app handles requests:
app.UseHttpsRedirection();    // Forces secure connections
app.UseStaticFiles();          // Serves images, audio, CSS
app.UseRouting();              // Handles URL navigation
app.MapBlazorHub();            // Sets up real-time connection
app.MapFallbackToPage("/_Host"); // Default page when no match

app.Run();  // Starts the server!
```

**What "Singleton" means**: When you see `AddSingleton<PointsService>()`, it means there's only ONE instance of the points tracker. Every page that asks for it gets the SAME one. That's how the points stay consistent as users navigate.

### The Brain: PointsService.cs

This service manages all the points logic. Here's what each method does:

| Method | What It Does | When It's Used |
|--------|--------------|----------------|
| `SubtractPoints(int)` | Removes points from balance | When selecting an item |
| `AddPoints(int)` | Adds points back (max 500) | When deselecting or refunding |
| `ResetPoints()` | Sets back to 500, clears selections | On "Start Over" |
| `HasEnoughPoints(int)` | Returns true/false | Before allowing a selection |
| `UpdateSelection(category, cost)` | Smart update - refunds old, charges new | When changing a selection |
| `RefundCategory(category)` | Returns points for a category | When navigating back |
| `GetAllSelections()` | Returns dictionary of all choices | For summary display |

**The Event System**: `OnPointsChanged` is an "event" that fires whenever points change. The layout subscribes to this event so the points badge updates instantly.

### The Pages: How Each One Works

Every page follows the same pattern:

```
1. @page "/route-name"          ← What URL shows this page
2. @inject PointsService        ← Get access to points tracker
3. @inject NavigationManager    ← Get ability to navigate
4. <HTML for the page>          ← What users see
5. @code { ... }                ← C# logic for functionality
6. <style> ... </style>         ← CSS styling
```

**Example breakdown from Books.razor**:

```csharp
// This runs when user clicks a book
private void SelectBook(string bookId, int cost)
{
    // Step 1: Check if they can afford it
    if (!PointsService.HasEnoughPoints(cost) && selectedBook != bookId)
    {
        showError = true;  // Show error message
        return;            // Stop here, don't proceed
    }

    // Step 2: If clicking same book, deselect it
    if (selectedBook == bookId)
    {
        selectedBook = "";                    // Clear selection
        PointsService.RefundCategory("book"); // Give points back
    }
    else
    {
        // Step 3: Select the new book
        selectedBook = bookId;
        PointsService.UpdateSelection("book", cost); // Charge points
    }
}
```

### The Components: Reusable Pieces

**ChatBubble.razor** - The Mr. B-Day mascot:
- Takes 3 parameters: `Title`, `Message`, `AudioFile`
- The entire cake character is drawn with CSS (no images!)
- Has 15+ different animations running simultaneously:
  - Bouncing body
  - Blinking eyes
  - Waving arms
  - Kicking legs
  - Flickering candle flames
  - Floating confetti/sparkles

**PageHeader.razor** - The title banner:
- Takes 1 parameter: `Title`
- Creates consistent gradient header across all pages
- Has subtle pulsing animation

### The Layout: MainLayout.razor

This wraps every page and provides:
- The points badge (top-right corner)
- Consistent background
- The `@Body` placeholder where page content appears

```razor
<div class="points-badge">
    Points Remaining: @PointsService.CurrentPoints / 500
</div>

<main>
    @Body  <!-- Each page's content appears here -->
</main>
```

### Styling Approach

The app uses **component-scoped CSS**. Each `.razor` file has its own `<style>` block at the bottom. This means:
- Styles only affect that specific component
- No conflicts between pages
- Easy to modify one page without affecting others

**Key design patterns used**:
- `linear-gradient()` for colorful backgrounds
- `@keyframes` for animations
- `flexbox` and `grid` for layouts
- Media queries for responsiveness

---

## SECTION 12: HOW TO MODIFY PRODUCTS

This section shows exactly how to add, remove, or change products in each category.

### Adding a New Sweet Treat

**File to edit**: `Pages/SweetTreats.razor`

**Find this section** (around line 62):
```csharp
private readonly List<Treat> treats = new List<Treat>
{
    new Treat { Id = "cookies-mm", Name = "Cookies - M&M", Points = 25 },
    // ... other treats
};
```

**To add a new treat**, add a new line:
```csharp
new Treat { Id = "cupcake-vanilla", Name = "Vanilla Cupcake", Points = 30 },
```

**Rules**:
- `Id` must be unique (used internally)
- `Name` is what users see
- `Points` is the cost

### Adding a New Book

**File to edit**: `Pages/Books.razor`

Books are hardcoded in the HTML. Find the tier you want to add to:

```html
<!-- Tier 1: Picture Books -->
<div class="tier-section">
    <div class="tier-options">
        <div class="book-option @(selectedBook == "rhyming" ? "selected" : "")"
             @onclick='() => SelectBook("rhyming", 15)'>
            <span class="book-name">Rhyming Stories</span>
        </div>
        <!-- ADD NEW BOOK HERE -->
        <div class="book-option @(selectedBook == "newbook" ? "selected" : "")"
             @onclick='() => SelectBook("newbook", 15)'>
            <span class="book-name">My New Book Title</span>
        </div>
    </div>
</div>
```

**Important**: The first parameter in `SelectBook("newbook", 15)` is the unique ID, the second is the point cost.

### Adding a New Gift

**File to edit**: `Pages/Gifts.razor`

Similar to books, find the tier and add:

```html
<div class="gift-option @(IsGiftSelected("new-gift-id") ? "selected" : "")"
     @onclick='() => ToggleGift("new-gift-id", 50)'>
    <span class="gift-name">New Gift Set Name</span>
</div>
```

### Changing Point Values

Simply change the number in the method call:

```csharp
// Change this:
@onclick='() => SelectBook("rhyming", 15)'

// To this (new price of 20 points):
@onclick='() => SelectBook("rhyming", 20)'
```

**Don't forget** to also update the displayed price in the tier header if you change costs.

### Adding a New Birthday Card

**File to edit**: `Pages/BirthdayCards.razor`

Find the card grid and add:
```html
<div class="card-option @(selectedCard == "card7" ? "selected" : "")"
     @onclick='() => SelectCard("card7")'>
    <div class="card-title">Card 7</div>
</div>
```

**Note**: All birthday cards cost 10 points (hardcoded in the `SelectCard` method).

### Adding New Colors for Customization

**File to edit**: `Pages/Customized.razor`

Find the colors list and add:
```csharp
private readonly List<string> availableColors = new List<string>
{
    "Black", "Brown", "Red", "Yellow", "Purple",
    "Pink", "Green", "White", "Orange", "Blue",
    "Gold", "Silver"  // <-- Add new colors here
};
```

---

## SECTION 13: DATABASE INTEGRATION GUIDANCE

Currently, the app stores nothing permanently. Here's how to add database support:

### Step 1: Add Entity Framework Core

Run in terminal:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Step 2: Create Data Models

Create a new folder called `Models` and add:

```csharp
// Models/Order.cs
public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string ChildName { get; set; }
    public int PointsUsed { get; set; }
    public int PointsRemaining { get; set; }

    // Selections
    public string BirthdayCardId { get; set; }
    public string BookId { get; set; }
    public string SweetTreatId { get; set; }
    public string CustomizationColors { get; set; }
    public string GiftIds { get; set; }  // Comma-separated

    // Survey responses
    public string SurveyExperience { get; set; }
    public string SurveyFeeling { get; set; }
    public string SurveyMrBDayOpinion { get; set; }
}
```

### Step 3: Create Database Context

```csharp
// Data/BirthdayMarketContext.cs
using Microsoft.EntityFrameworkCore;

public class BirthdayMarketContext : DbContext
{
    public BirthdayMarketContext(DbContextOptions<BirthdayMarketContext> options)
        : base(options) { }

    public DbSet<Order> Orders { get; set; }
}
```

### Step 4: Register in Program.cs

```csharp
// Add this line:
builder.Services.AddDbContext<BirthdayMarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### Step 5: Add Connection String

In `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=BirthdayMarket;Trusted_Connection=True;"
  }
}
```

### Step 6: Create the Database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Step 7: Save Orders on Congratulations Page

Inject the context and save:
```csharp
@inject BirthdayMarketContext DbContext

// In the code section:
private async Task SaveOrder()
{
    var order = new Order
    {
        OrderDate = DateTime.Now,
        PointsUsed = PointsService.PointsUsed,
        // ... fill in other fields
    };

    DbContext.Orders.Add(order);
    await DbContext.SaveChangesAsync();
}
```

---

## SECTION 14: DEPLOYMENT INSTRUCTIONS

### Option 1: Local Development (Testing)

1. **Install Prerequisites**:
   - .NET 8 SDK from https://dotnet.microsoft.com/download
   - Visual Studio 2022 OR Visual Studio Code with C# extension

2. **Run the Application**:
   ```bash
   cd BirthdayMarket_CEAJ
   dotnet run
   ```

3. **Access in Browser**:
   - Open https://localhost:5001 or http://localhost:5000

### Option 2: Deploy to IIS (Windows Server)

1. **Publish the Application**:
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Install Prerequisites on Server**:
   - ASP.NET Core 8.0 Hosting Bundle
   - IIS with WebSocket support enabled

3. **Create IIS Site**:
   - Point to the `publish` folder
   - Set Application Pool to "No Managed Code"
   - Enable WebSockets in IIS features

### Option 3: Deploy to Azure App Service

1. **Publish from Visual Studio**:
   - Right-click project → Publish
   - Select Azure App Service
   - Follow wizard

2. **Or use Azure CLI**:
   ```bash
   az webapp up --name BirthdayMarket --resource-group MyGroup --runtime "DOTNET|8.0"
   ```

### Option 4: Docker Container

Create a `Dockerfile`:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BirthdayMarket.dll"]
```

Build and run:
```bash
docker build -t birthdaymarket .
docker run -p 8080:80 birthdaymarket
```

### Environment Configuration

For production, update `Program.cs`:
- Enable HTTPS redirection
- Configure proper error handling
- Set up logging

Update `appsettings.Production.json` with production database connection strings.

---

## SECTION 15: FILE-BY-FILE REFERENCE

### Complete File List with Descriptions

| File | Purpose | Lines of Code (approx) |
|------|---------|------------------------|
| `Program.cs` | Application startup and configuration | 30 |
| `App.razor` | Root router component | 15 |
| `_Imports.razor` | Global namespace imports | 10 |
| `BirthdayMarket.csproj` | Project configuration | 10 |

**Pages Folder:**

| File | Route | Purpose | Key Logic |
|------|-------|---------|-----------|
| `Index.razor` | `/` | Welcome screen | START button navigation |
| `Intro.razor` | `/intro` | Mr. B-Day introduction | Audio playback, icons |
| `BirthdayCards.razor` | `/birthday-cards` | Card selection | 10pts, single select |
| `Books.razor` | `/books` | Book selection | 15-25pts, 3 tiers |
| `SweetTreats.razor` | `/sweet-treats` | Treat selection | 20-50pts, allergen warning |
| `Customized.razor` | `/customized` | Name + colors | Free, optional |
| `Gifts.razor` | `/gifts` | Gift selection | 50-100pts, multi-select |
| `Survey.razor` | `/survey` | 3 questions | All required |
| `Congratulations.razor` | `/congratulations` | Celebration | Confetti, summary |

**Components Folder:**

| File | Purpose | Parameters |
|------|---------|------------|
| `ChatBubble.razor` | Mr. B-Day mascot + speech | Title, Message, AudioFile |
| `PageHeader.razor` | Page title headers | Title |

**Services Folder:**

| File | Purpose | Key Methods |
|------|---------|-------------|
| `PointsService.cs` | Points management | SubtractPoints, AddPoints, UpdateSelection, RefundCategory |

**Shared Folder:**

| File | Purpose |
|------|---------|
| `MainLayout.razor` | Master layout with points badge |

**wwwroot Folder (Static Assets):**

| Subfolder | Contents |
|-----------|----------|
| `css/` | Global stylesheets |
| `images/` | Card images, icons |
| `audio/` | MP3 narration files for each page |

---

## SECTION 16: TROUBLESHOOTING GUIDE

### Common Issues and Solutions

**Issue**: "Points aren't updating on the page"
> **Cause**: The page isn't subscribed to the `OnPointsChanged` event
> **Solution**: Add `@implements IDisposable` and subscribe in `OnInitialized`

**Issue**: "Audio doesn't play"
> **Cause**: Browser autoplay policies block audio without user interaction
> **Solution**: This is browser behavior; users may need to click to enable audio

**Issue**: "App shows 'Connection lost' message"
> **Cause**: Blazor Server requires constant connection
> **Solution**: Check network; page will auto-reconnect when connection restored

**Issue**: "Changes to code don't appear"
> **Cause**: Browser caching
> **Solution**: Hard refresh (Ctrl+F5) or clear browser cache

**Issue**: "New treats/books don't show up"
> **Cause**: Syntax error in the code
> **Solution**: Check for missing commas, brackets, or quotation marks

---

*This document should prepare you to confidently answer most questions about the BirthdayMarket application. If you encounter questions not covered here, the honest answer is "I'll need to check with the development team on that specific detail."*
