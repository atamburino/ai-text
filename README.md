```
├── README.md
├── .gitignore
├── src/
│   ├── AIAnalyzer.Api/           # Main API project
│   ├── AIAnalyzer.Core/          # Core logic (ML.NET models)
│   └── AIAnalyzer.Tests/         # Unit and integration tests
├── datasets/                     # Training datasets (if needed)
├── docker/                       # Docker configuration
└── docs/                         # Documentation
```

# AI Text Analyzer
A lightweight AI-powered tool for text summarization and sentiment analysis, built with C# and ML.NET.

## Features
- Summarize large blocks of text into concise summaries.
- Analyze sentiment from user feedback or reviews.

## Tech Stack
- Backend: ASP.NET Core, ML.NET
- Frontend: React (optional)
- Deployment: Docker, Azure

## Roadmap
- [x] Project Initialization
- [ ] AI Model Integration
- [ ] User Interaction
- [ ] Deployment

## Configuration

### API Keys
For security reasons, API keys are not stored in the repository. To set up your development environment:

1. Create a `.env` file in the root directory
2. Add your API keys to this file:
```
DEEPSEEK_API_KEY=your_api_key_here
```

The application will automatically load the environment variables from the `.env` file.

**IMPORTANT: Never commit API keys to version control!**
- The `.env` file is ignored by git
- For production, use environment variables or a secure key management service
- Rotate your API keys if they are ever exposed

## How to Run Locally
1. Clone the repository: `git clone https://github.com/your-username/ai-text.git`
2. Navigate to the API project: `cd src/AIAnalyzer.Api`
3. Create `.env` file with your API keys
4. Run the API: `dotnet run`
5. (Optional) Run the UI: `cd src/UI && npm start`

## Contributing
Feel free to fork the repo and open a pull request!
