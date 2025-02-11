Jeffery Chatbot
This repository contains the implementation of "Jeffery," a chatbot developed using Azure OpenAI services. Jeffery is designed to answer user queries in a warm and fun way. The chatbot leverages Azure Cognitive Services, specifically the GPT-4.0-mini model, to generate human-like responses based on the provided chat history.

Prerequisites
Before running the chatbot, ensure you have the following prerequisites installed:

.NET Core SDK

Azure CLI

Azure subscription with access to OpenAI services

Environment variable AZURE_OPENAI_ENDPOINT set to your OpenAI endpoint

Installation
Clone the repository:

bash
git clone <repository-url>
cd <repository-directory>
Install the required .NET packages:

bash
dotnet restore
Set up Azure authentication:

Ensure you have the InteractiveBrowserCredential for passwordless authentication.

Set the environment variable:

bash
export AZURE_OPENAI_ENDPOINT=https://team2openai.openai.azure.com/
Usage
Run the chatbot:

bash
dotnet run
Interact with the chatbot:

Provide your name when prompted.

Type 'exit' to end the conversation.

Chat with Jeffery, who will respond to your queries in a warm and fun manner.

Code Explanation
Imports:

The code imports necessary namespaces, including System, System.Collections.Generic, System.Threading.Tasks, and Azure OpenAI services.

Environment Setup:

The OpenAI endpoint is retrieved from environment variables. If not set, a message prompts the user to set it.

Authentication:

The code uses InteractiveBrowserCredential for Entra ID authentication, enabling passwordless login.

Initialization:

The AzureOpenAIClient is initialized with the specified endpoint and credentials. A ChatClient is created with the deployment name gpt-4o-mini.

Chat History and Options:

The chat history is initialized with a system message describing the assistant's personality. Chat completion options, including Temperature, MaxOutputTokenCount, FrequencyPenalty, and PresencePenalty, are set.

Chat Loop:

The chatbot enters a loop where it reads user input, sends it to the OpenAI service, and prints the assistant's response. The conversation continues until the user types 'exit'.

Error Handling
The code includes basic error handling to catch and display exceptions that may occur during the chat completion process.

Contributing
Feel free to open issues or submit pull requests if you find any bugs or have suggestions for improvements.

License
This project is licensed under the MIT License. See the LICENSE file for details.
