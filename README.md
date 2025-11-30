# UWC Application Form - Blazor WebAssembly with TypeScript

A modern, student-friendly online application form for the University of Western Cape, built with Blazor WebAssembly and TypeScript.

## 🎨 Features

### Design & UX
- **UWC Color Scheme**: Deep navy blue (#1e3a8a) primary, gold (#f59e0b) accents
- **Responsive Design**: Mobile-first approach with breakpoints for tablet and desktop
- **Modern UI**: Floating label inputs, custom radio/checkbox styling, smooth animations
- **Progress Tracking**: Visual progress indicator showing completion percentage
- **Multi-step Form**: 10 sections with smooth slide transitions
- **Auto-save**: Automatic progress saving every 30 seconds to localStorage

### Form Sections
1. **Application Details** - Personal information and identification
2. **Academic Background** - Educational history
3. **Contact Information** - Address and communication details
4. **Study Preferences** - Program choices and study mode
5. **Documents Upload** - Drag-and-drop file uploads
6. **Previous Studies** - Tertiary education history
7. **Financial Information** - Funding options
8. **Emergency Contact** - Emergency contact details
9. **Additional Information** - Disability support and accommodation
10. **Review & Submit** - Final review and submission

### Technical Features
- **TypeScript Modules**: Swipe detection, localStorage helpers, form utilities
- **Client-side Validation**: DataAnnotations with real-time feedback
- **State Management**: Scoped service with localStorage persistence
- **Touch Gestures**: Swipe left/right navigation on mobile
- **Accessibility**: ARIA labels, keyboard navigation, screen reader support
- **Animations**: Smooth transitions, confetti on submission

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18 or higher) - for TypeScript compilation
- A modern web browser (Chrome, Firefox, Edge, or Safari)

### Installation

1. **Clone or navigate to the project directory**
   ```powershell
   cd UWCApplicationForm
   ```

2. **Install npm dependencies**
   ```powershell
   npm install
   ```

3. **Compile TypeScript files**
   ```powershell
   npm run build:ts
   ```

4. **Restore .NET dependencies**
   ```powershell
   dotnet restore
   ```

### Running the Application

#### Option 1: Using .NET CLI (Recommended)

```powershell
dotnet run
```

The application will start and be available at:
- https://localhost:5001
- http://localhost:5000

#### Option 2: Using Visual Studio 2022

1. Open `UWCApplicationForm.csproj` in Visual Studio
2. Press F5 or click "Start Debugging"

#### Option 3: Development Mode with TypeScript Watch

For active TypeScript development:

```powershell
# Terminal 1: Watch TypeScript files
npm run watch:ts

# Terminal 2: Run Blazor app
dotnet watch run
```

This enables hot reload for both TypeScript and Blazor files.

### Building for Production

```powershell
# Compile TypeScript
npm run build:ts

# Build Blazor app
dotnet publish -c Release -o ./publish
```

The published files will be in the `./publish/wwwroot` directory.

## 📁 Project Structure

```
UWCApplicationForm/
├── Components/                    # Reusable Blazor components
│   ├── BannerComponent.razor
│   ├── FileUpload.razor
│   ├── FormNavigationBreadcrumb.razor
│   ├── FormSectionContainer.razor
│   ├── HeaderSection.razor
│   ├── InputFloating.razor
│   ├── NavigationButtons.razor
│   └── ProgressIndicator.razor
├── Layout/                        # Layout components
│   └── MainLayout.razor
├── Models/                        # Data models
│   └── ApplicationFormModel.cs
├── Pages/                         # Page components
│   └── ApplicationForm.razor      # Main application form
├── Services/                      # Application services
│   └── FormStateService.cs
├── TypeScript/                    # TypeScript source files
│   ├── formHelpers.ts
│   ├── localStorageHelper.ts
│   ├── main.ts
│   └── swipeDetection.ts
├── wwwroot/                       # Static files
│   ├── css/
│   │   └── app.css               # Custom styles
│   ├── js/                       # Compiled TypeScript output
│   └── index.html
├── App.razor
├── Program.cs
├── _Imports.razor
├── package.json
├── tsconfig.json
└── UWCApplicationForm.csproj
```

## 🎯 Key Components

### TypeScript Modules

#### SwipeDetection
Handles touch gestures for mobile navigation:
```typescript
SwipeDetection.initialize(elementId, dotNetHelper);
```

#### LocalStorageHelper
Type-safe localStorage operations:
```typescript
LocalStorageHelper.save(key, data);
LocalStorageHelper.load(key);
```

#### FormHelpers
Form utilities including:
- SA ID number formatting and validation
- Phone number formatting
- Email validation
- Toast notifications
- Confetti animation
- Auto-focus management

### Blazor Services

#### FormStateService
Manages application state with features:
- Auto-save to localStorage
- Section navigation
- Progress tracking
- Form completion percentage calculation

## 🎨 Styling

The application uses:
- **Tailwind CSS** (CDN) for utility classes
- **Custom CSS** (`wwwroot/css/app.css`) for:
  - Animations (slide-in, fade, shake, confetti)
  - UWC badge styling with gold glow
  - Floating label inputs
  - Custom radio/checkbox controls
  - Progress indicators

### Color Palette

```css
--uwc-navy: #1e3a8a
--uwc-gold: #f59e0b
--uwc-light-gray: #f8fafc
--success-green: #10b981
--error-red: #ef4444
```

## 🧪 Testing

### Manual Testing Checklist

1. **Form Navigation**
   - [ ] Next/Previous buttons work
   - [ ] Breadcrumb navigation works
   - [ ] Progress dots are clickable
   - [ ] Swipe gestures work on mobile

2. **Validation**
   - [ ] Required fields show errors
   - [ ] Email validation works
   - [ ] Email confirmation matches
   - [ ] SA ID number validation works

3. **Auto-save**
   - [ ] Form saves every 30 seconds
   - [ ] "Last saved" indicator updates
   - [ ] Data persists on page refresh

4. **File Upload**
   - [ ] Drag-and-drop works
   - [ ] Click to upload works
   - [ ] File size validation works
   - [ ] Multiple file uploads work

5. **Submission**
   - [ ] Terms agreement required
   - [ ] Confetti animation plays
   - [ ] Success message shows
   - [ ] Form clears after submission

### Browser Testing

Test in the following browsers:
- Chrome (latest)
- Firefox (latest)
- Edge (latest)
- Safari (latest)
- Mobile browsers (iOS Safari, Chrome Android)

### Responsive Testing

Test at these breakpoints:
- Mobile: 375px (iPhone SE)
- Mobile: 414px (iPhone Pro Max)
- Tablet: 768px (iPad)
- Tablet: 1024px (iPad Pro)
- Desktop: 1440px
- Desktop: 1920px

## 🔧 Configuration

### TypeScript Configuration

Edit `tsconfig.json` to modify TypeScript compiler options:
- Target ES version
- Module system
- Output directory
- Source maps

### Tailwind Configuration

Tailwind is configured inline in `wwwroot/index.html`:
```javascript
tailwind.config = {
    theme: {
        extend: {
            colors: {
                'uwc-navy': '#1e3a8a',
                'uwc-gold': '#f59e0b',
            }
        }
    }
}
```

## 📝 Development Notes

### Adding a New Form Section

1. Add properties to `ApplicationFormModel.cs`
2. Create the section in `ApplicationForm.razor`
3. Update `GetSectionNames()` in `FormStateService.cs`
4. Add validation logic if needed

### Customizing Animations

Edit `wwwroot/css/app.css`:
- Modify `@keyframes` definitions
- Adjust animation duration/timing
- Add new animation classes

### TypeScript Development

1. Make changes in `TypeScript/` folder
2. Run `npm run build:ts` or `npm run watch:ts`
3. Compiled JS appears in `wwwroot/js/`
4. Refresh browser to see changes

## 🐛 Troubleshooting

### TypeScript files not compiling

```powershell
# Verify Node.js installation
node --version

# Reinstall dependencies
npm install

# Manually compile
npx tsc
```

### Blazor app not starting

```powershell
# Clean and rebuild
dotnet clean
dotnet build

# Check for errors
dotnet build --no-incremental
```

### LocalStorage not working

- Check browser privacy settings
- Ensure cookies/local storage are enabled
- Try incognito/private mode
- Clear browser cache

### Styles not applying

- Hard refresh: Ctrl+Shift+R (Windows) or Cmd+Shift+R (Mac)
- Check browser console for CSS errors
- Verify Tailwind CDN is loading

## 📄 License

This project is for educational and demonstration purposes.

## 🤝 Contributing

This is a demonstration project. For production use:
1. Add server-side validation
2. Implement actual file upload handling
3. Add database integration
4. Implement email confirmation
5. Add reCAPTCHA for bot protection
6. Implement proper authentication

## 🌐 GitHub Pages Deployment

This project is configured to automatically deploy to GitHub Pages when you push to the `main` branch.

### Live Site

Once deployed, your application will be available at:
`https://<your-username>.github.io/UWCApplicationForm/`

### Setup Instructions

1. **Create a GitHub repository named `UWCApplicationForm`** at https://github.com/new

2. **Configure GitHub Pages**:
   - Go to your repository → Settings → Pages
   - Under "Build and deployment", select "GitHub Actions" as the source

3. **Push your code** (the GitHub Actions workflow will automatically deploy):
   ```powershell
   git add .
   git commit -m "Initial commit"
   git branch -M main
   git remote add origin https://github.com/<your-username>/UWCApplicationForm.git
   git push -u origin main
   ```

4. **Monitor deployment**:
   - Go to the "Actions" tab in your repository
   - Watch the deployment workflow run
   - Once complete (usually 2-3 minutes), your site will be live!

### How It Works

The `.github/workflows/deploy.yml` file automatically:
1. Installs .NET 8.0 and Node.js
2. Installs npm dependencies
3. Compiles TypeScript files
4. Builds the Blazor WebAssembly app
5. Updates the base path for GitHub Pages
6. Deploys to GitHub Pages

### Local Testing with Production Base Path

To test locally with the GitHub Pages base path:
```powershell
dotnet publish -c Release -o ./publish
# Manually edit publish/wwwroot/index.html base href to "/UWCApplicationForm/"
# Then serve the publish/wwwroot folder
```

## 📞 Support

For issues or questions:
- Check browser console for errors
- Review this README thoroughly
- Ensure all prerequisites are installed
- Verify TypeScript compilation succeeded

## 🎓 University of Western Cape

This application form is a modern, student-friendly interface inspired by UWC's online systems.

**Your Future Starts Here - Apply to UWC** 🎓
