

# Book Management Web API

A simple ASP.NET Core Web API for managing a collection of books. This project allows users to add, update, retrieve, and delete books. It is deployed on Azure App Service and can be monitored using Application Insights.

## Features

- **Add a book**: Provide title, author, description, and publish date.
- **Update a book**: Modify book details.
- **Delete a book**: Remove a book from the list.
- **Retrieve books**: Get a list of all books.

## Technology Stack

- **Backend**: ASP.NET Core 6.0 Web API
- **Frontend**: HTML, CSS
- **Cloud Platform**: Microsoft Azure
- **CI/CD**: GitHub Actions
- **Monitoring**: Application Insights (Azure)

## Deployment Process

### 1. **Preparing the Azure Environment**

- **Azure App Service**: Created using Azure Portal.
- **Region & Pricing Plan**: Selected a student-supported plan.
- **SCM Configuration**: Enabled in App Service to allow deployment from GitHub.

### 2. **CI/CD Setup**

- Configured **GitHub Actions** for Continuous Integration/Continuous Deployment (CI/CD).
- Steps include building the project with `.NET Core`, publishing artifacts, and deploying to **Azure Web App** using the `azure/webapps-deploy` GitHub action.

### 3. **Application Insights**

- **Application Insights** has been enabled for monitoring application performance.
- Allows real-time tracking of response times, requests, and errors.
- Traffic simulation was done to test performance.

### 4. **Deployment Instructions**

1. **Build Process**: The project is automatically built and deployed on every push to the `master` branch via GitHub Actions.
2. **Deployment Slot**: The app is deployed to the production slot of Azure App Service.
3. **Live URL**: The web API is available at `https://<your-app-service-name>.azurewebsites.net`.

### 5. **Monitoring**

- Application Insights captures logs and performance metrics.
- Real-time metrics like CPU usage, memory, and request rates can be monitored.

## Running Locally

### Prerequisites

- **.NET Core SDK** (6.0 or higher)
- **Azure Account** (optional for deployment)
- **GitHub Account**

### Steps to Run Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/book-management-api.git
   ```
2. Navigate to the project directory:
   ```bash
   cd BookManagementAPI
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the project:
   ```bash
   dotnet build
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

The API will be available locally at `https://localhost:7096`, `https://localhost:5096`.

### API Endpoints

- `GET /api/books` - Get a list of all books.
- `POST /api/books` - Add a new book.
- `PUT /api/books/{id}` - Update an existing book.
- `DELETE /api/books/{id}` - Delete a book by ID.

## Contributing

Feel free to submit issues and pull requests if you want to contribute to this project.

