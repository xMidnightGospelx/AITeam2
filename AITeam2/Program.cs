
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using OpenAI.Chat;

using static System.Environment;
using static System.Net.WebRequestMethods;

async Task RunAsync()
{
    // Retrieve the OpenAI endpoint from environment variables
    var endpoint = "https://team2openai.openai.azure.com/";
    if (string.IsNullOrEmpty(endpoint))
    {
        Console.WriteLine("Please set the AZURE_OPENAI_ENDPOINT environment variable.");
        return;
    }

    // Use DefaultAzureCredential for Entra ID authentication
    var credentials = new InteractiveBrowserCredential(); // Use this line for Passwordless auth

    // Initialize the AzureOpenAIClient
    var azureClient = new AzureOpenAIClient(new Uri(endpoint), credentials);

    // Initialize the ChatClient with the specified deployment name
    ChatClient chatClient = azureClient.GetChatClient("gpt-4o-mini");

    // Create a chat history object
    var chatHistory = new List<ChatMessage>
    {
        new SystemChatMessage("You are a helpful assistant, called Jeffery that answers in a warm and fun way.")
    };

    // Create chat completion options
    var options = new ChatCompletionOptions
    {
        Temperature = (float)0.7,
        MaxOutputTokenCount = 800,
        FrequencyPenalty = 0,
        PresencePenalty = 0,
    };
    Console.WriteLine("What is your Name?");
    string name = Console.ReadLine();
    Console.WriteLine("Welcome to the Jeffery chatbot! Type 'exit' to end the conversation.");
    while (true)
    {
        Console.Write($"{name}: ");
        string userInput = Console.ReadLine();

        if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        chatHistory.Add(new UserChatMessage(userInput));

        try
        {
            // Create the chat completion request
            ChatCompletion completion = await chatClient.CompleteChatAsync(chatHistory, options);

            // Print the response
            if (completion.Content != null && completion.Content.Count > 0)
            {
                var assistantMessage = completion.Content[0].Text;
                Console.WriteLine($"Jeffery: {assistantMessage}");
                chatHistory.Add(new AssistantChatMessage(assistantMessage));
            }
            else
            {
                Console.WriteLine("No response received.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

await RunAsync();