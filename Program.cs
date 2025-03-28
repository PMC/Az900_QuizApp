using System.Text.Json;
// ReSharper disable All
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

namespace Az900_QuizApp
{
    public class Question
    {
        public int question_id { get; set; }
        public string? question { get; set; }
        public List<string>? options { get; set; }
    }

    public class Answer
    {
        public int question_id { get; set; }
        public string? correct_option { get; set; }
    }

    class Program
    {
        const string quizQuestionsJson = @"
        [
            {
                ""question_id"": 1,
                ""question"": ""Which tool helps estimate the cost of Azure services before deployment?"",
                ""options"": [
                    ""Azure Cost Management"",
                    ""Azure Pricing Calculator"",
                    ""Azure Advisor"",
                    ""Azure Monitor""
                ]
            },
            {
                ""question_id"": 2,
                ""question"": ""What is the purpose of the Total Cost of Ownership (TCO) calculator?"",
                ""options"": [
                    ""Compare the cost of on-premises infrastructure with Azure"",
                    ""Track the actual cost of Azure services"",
                    ""Provide discounts for bulk purchases"",
                    ""Monitor Azure security compliance""
                ]
            },
            {
                ""question_id"": 3,
                ""question"": ""Which factor does NOT affect Azure costs?"",
                ""options"": [
                    ""Region selection"",
                    ""Resource type"",
                    ""Deployment location within an Azure region"",
                    ""Internet speed of the user""
                ]
            },
            {
                ""question_id"": 4,
                ""question"": ""How can Azure tags help in cost management?"",
                ""options"": [
                    ""They enhance security"",
                    ""They organize and categorize resources for cost tracking"",
                    ""They improve network performance"",
                    ""They enforce compliance policies""
                ]
            },
            {
                ""question_id"": 5,
                ""question"": ""What does Azure Cost Management NOT provide?"",
                ""options"": [
                    ""Budgeting and alerts"",
                    ""Cost forecasting"",
                    ""Subscription cancellation"",
                    ""Billing reports""
                ]
            },
            {
                ""question_id"": 6,
                ""question"": ""What is the main purpose of Azure Policy?"",
                ""options"": [
                    ""Enforce compliance and best practices"",
                    ""Manage user authentication"",
                    ""Encrypt virtual machines"",
                    ""Monitor application performance""
                ]
            },
            {
                ""question_id"": 7,
                ""question"": ""How does Azure Blueprints help with governance?"",
                ""options"": [
                    ""By designing machine learning models"",
                    ""By enforcing compliance policies automatically"",
                    ""By securing the network perimeter"",
                    ""By accelerating virtual machine performance""
                ]
            },
            {
                ""question_id"": 8,
                ""question"": ""What is the purpose of resource locks in Azure?"",
                ""options"": [
                    ""Restrict unauthorized user access"",
                    ""Prevent accidental modification or deletion of resources"",
                    ""Improve virtual machine performance"",
                    ""Enable automatic scaling of services""
                ]
            },
            {
                ""question_id"": 9,
                ""question"": ""Which Azure governance tool provides reports on regulatory compliance?"",
                ""options"": [
                    ""Azure Monitor"",
                    ""Microsoft Purview"",
                    ""Azure Arc"",
                    ""Azure Advisor""
                ]
            },
            {
                ""question_id"": 10,
                ""question"": ""What does the Service Trust Portal provide?"",
                ""options"": [
                    ""Security and compliance information"",
                    ""Pricing calculators"",
                    ""Virtual machine recommendations"",
                    ""Performance tuning for Azure services""
                ]
            },
            {
                ""question_id"": 11,
                ""question"": ""Which of the following is NOT a tool for deploying Azure resources?"",
                ""options"": [
                    ""Azure Portal"",
                    ""PowerShell"",
                    ""CLI"",
                    ""Microsoft Office""
                ]
            },
            {
                ""question_id"": 12,
                ""question"": ""What is the purpose of Azure Resource Manager (ARM)?"",
                ""options"": [
                    ""Manage and deploy Azure resources"",
                    ""Encrypt Azure storage"",
                    ""Monitor Azure services"",
                    ""Manage Azure billing""
                ]
            },
            {
                ""question_id"": 13,
                ""question"": ""Which tool enables infrastructure as code (IaC) deployment in Azure?"",
                ""options"": [
                    ""Azure Advisor"",
                    ""Azure Monitor"",
                    ""ARM Templates"",
                    ""Azure Cost Management""
                ]
            },
            {
                ""question_id"": 14,
                ""question"": ""Which Azure service allows managing on-premises and multi-cloud resources?"",
                ""options"": [
                    ""Azure Purview"",
                    ""Azure Arc"",
                    ""Azure Monitor"",
                    ""Azure Service Health""
                ]
            },
            {
                ""question_id"": 15,
                ""question"": ""What is the main purpose of Azure Bicep?"",
                ""options"": [
                    ""Provide security policies"",
                    ""Simplify Azure infrastructure as code (IaC) using ARM"",
                    ""Monitor Azure services"",
                    ""Optimize cost management""
                ]
            },
            {
                ""question_id"": 16,
                ""question"": ""What is Azure Monitor used for?"",
                ""options"": [
                    ""Enforcing security policies"",
                    ""Maximizing application availability and performance"",
                    ""Managing user authentication"",
                    ""Preventing unauthorized access To virtual machines""
                ]
            },
            {
                ""question_id"": 17,
                ""question"": ""Which tool provides best practice recommendations for Azure resources?"",
                ""options"": [
                    ""Azure Advisor"",
                    ""Azure Purview"",
                    ""Azure Resource Manager"",
                    ""Azure TC    Calculator""
                ]
            },
            {
                ""question_id"": 18,
                ""question"": ""What are the three components of Azure Service Health?"",
                ""options"": [
                    ""Virtual Machines, Networking, Storage"",
                    ""Azure Status, Service Health, Resource Health"",
                    ""Monitoring, Reporting, Billing"",
                    ""Compliance, Security, Cost Management""
                ]
            },
            {
                ""question_id"": 19,
                ""question"": ""Which Azure tool provides real-time alerts on performance issues?"",
                ""options"": [
                    ""Azure Advisor"",
                    ""Azure Log Analytics"",
                    ""Azure Service Health"",
                    ""Azure Cost Management""
                ]
            },
            {
                ""question_id"": 20,
                ""question"": ""What does Azure Application Insights monitor?"",
                ""options"": [
                    ""User activity logs"",
                    ""Security threats"",
                    ""Application performance and telemetry"",
                    ""Azure policy enforcement""
                ]
            },
            {
                ""question_id"": 21,
                ""question"": ""Which Azure service allows you To run applications without managing servers?"",
                ""options"": [
                    ""Virtual Machines"",
                    ""Azure Kubernetes Service (AKS)"",
                    ""Azure Functions"",
                    ""Azure SQL Database""
                ]
            },
            {
                ""question_id"": 22,
                ""question"": ""What is the primary benefit of using Azure Virtual Machines?"",
                ""options"": [
                    ""Automatic scaling without user intervention"",
                    ""Full control over the operating system and applications"",
                    ""N    need To manage resources"",
                    ""Reduced security concerns""
                ]
            },
            {
                ""question_id"": 23,
                ""question"": ""What is Azure Marketplace used for?"",
                ""options"": [
                    ""Selling Azure subscriptions"",
                    ""Finding and purchasing third-party applications and services"",
                    ""Managing virtual networks"",
                    ""Monitoring Azure security risks""
                ]
            },
            {
                ""question_id"": 24,
                ""question"": ""Which of the following is NOT a category of services available in Azure Marketplace?"",
                ""options"": [
                    ""Virtual Machine images"",
                    ""Application deployment software"",
                    ""Physical hardware components"",
                    ""Open-source container platforms""
                ]
            },
            {
                ""question_id"": 25,
                ""question"": ""What is the main benefit of Azure Logic Apps?"",
                ""options"": [
                    ""Encrypting storage accounts"",
                    ""Automating workflows and integrating cloud services"",
                    ""Managing security groups"",
                    ""Enhancing network performance""
                ]
            },
            {
                ""question_id"": 26,
                ""question"": ""What is the primary purpose of Azure Active Directory (Azure AD)?"",
                ""options"": [
                    ""Managing virtual machines"",
                    ""Enforcing network security"",
                    ""Managing user identities and access control"",
                    ""Optimizing Azure costs""
                ]
            },
            {
                ""question_id"": 27,
                ""question"": ""Which authentication method is recommended for Azure AD security?"",
                ""options"": [
                    ""Username and password only"",
                    ""Multi-Factor Authentication (MFA)"",
                    ""Single Sign-On (SSO) without additional verification"",
                    ""Only email-based authentication""
                ]
            },
            {
                ""question_id"": 28,
                ""question"": ""Which Azure service provides protection against Distributed Denial of Service (DDoS) attacks?"",
                ""options"": [
                    ""Azure Firewall"",
                    ""Azure DDoS Protection"",
                    ""Azure Security Center"",
                    ""Azure Policy""
                ]
            },
            {
                ""question_id"": 29,
                ""question"": ""What is the primary function of Microsoft Defender for Cloud?"",
                ""options"": [
                    ""Provide cost recommendations"",
                    ""Monitor Azure spending"",
                    ""Enhance security by identifying threats and vulnerabilities"",
                    ""Manage Azure subscriptions""
                ]
            },
            {
                ""question_id"": 30,
                ""question"": ""How can you restrict access To an Azure resource To specific users?"",
                ""options"": [
                    ""Using Azure AD role-based access control (RBAC)"",
                    ""Disabling the resource"",
                    ""Creating multiple copies of the resource"",
                    ""Enabling virtual networks""
                ]
            },
            {
                ""question_id"": 31,
                ""question"": ""Which Azure service enables private and secure communication between Azure resources?"",
                ""options"": [
                    ""Azure Virtual Network (VNet)"",
                    ""Azure Blob Storage"",
                    ""Azure AD"",
                    ""Azure Marketplace""
                ]
            },
            {
                ""question_id"": 32,
                ""question"": ""What is the purpose of Azure Load Balancer?"",
                ""options"": [
                    ""Distribute traffic across multiple servers for high availability"",
                    ""Secure virtual machines from cyber threats"",
                    ""Provide cost recommendations"",
                    ""Encrypt storage accounts""
                ]
            },
            {
                ""question_id"": 33,
                ""question"": ""Which service provides secure, dedicated network connectivity between on-premises data centers and Azure?"",
                ""options"": [
                    ""Azure Virtual Network"",
                    ""Azure ExpressRoute"",
                    ""Azure VPN Gateway"",
                    ""Azure Load Balancer""
                ]
            },
            {
                ""question_id"": 34,
                ""question"": ""What is a key benefit of using Azure Content Delivery Network (CDN)?"",
                ""options"": [
                    ""Reduced data storage costs"",
                    ""Faster delivery of web content by caching it closer To users"",
                    ""Improved identity and access management"",
                    ""Enhanced encryption for databases""
                ]
            },
            {
                ""question_id"": 35,
                ""question"": ""What is the purpose of Network Security Groups (NSGs) in Azure?"",
                ""options"": [
                    ""Manage cost alerts"",
                    ""Control inbound and outbound traffic To Azure resources"",
                    ""Deploy infrastructure as code"",
                    ""Automate application deployment""
                ]
            },
            {
                ""question_id"": 36,
                ""question"": ""Which Azure storage type is best for unstructured data, such as images and videos?"",
                ""options"": [
                    ""Azure Blob Storage"",
                    ""Azure Table Storage"",
                    ""Azure Queue Storage"",
                    ""Azure SQL Database""
                ]
            },
            {
                ""question_id"": 37,
                ""question"": ""What is Azure Files used for?"",
                ""options"": [
                    ""Secure file-sharing service with SMB protocol support"",
                    ""Storing structured data in relational databases"",
                    ""Managing network configurations"",
                    ""Encrypting virtual machines""
                ]
            },
            {
                ""question_id"": 38,
                ""question"": ""Which Azure storage replication option provides the highest availability?"",
                ""options"": [
                    ""Locally Redundant Storage (LRS)"",
                    ""Zone Redundant Storage (ZRS)"",
                    ""Geo-Redundant Storage (GRS)"",
                    ""Read-Access Geo-Redundant Storage (RA-GRS)""
                ]
            },
            {
                ""question_id"": 39,
                ""question"": ""Which of the following services provides a scalable NoSQL database in Azure?"",
                ""options"": [
                    ""Azure SQL Database"",
                    ""Azure Cosmos DB"",
                    ""Azure Blob Storage"",
                    ""Azure Virtual Machines""
                ]
            },
            {
                ""question_id"": 40,
                ""question"": ""How does Azure Backup help businesses?"",
                ""options"": [
                    ""By reducing network latency"",
                    ""By securing database connections"",
                    ""By protecting data from accidental deletion and ransomware attacks"",
                    ""By monitoring user activity""
                ]
            },
            {
                ""question_id"": 41,
                ""question"": ""What is the main advantage of Azure Virtual Machines?"",
                ""options"": [
                    ""Fully managed infrastructure"",
                    ""On-demand scalability"",
                    ""Reduced cost compared To all other services"",
                    ""N    need To configure networking""
                ]
            },
            {
                ""question_id"": 42,
                ""question"": ""Which Azure service allows you To scale web applications automatically?"",
                ""options"": [
                    ""Azure Virtual Machines"",
                    ""Azure App Service"",
                    ""Azure Kubernetes Service"",
                    ""Azure SQL Database""
                ]
            },
            {
                ""question_id"": 43,
                ""question"": ""What is the purpose of Azure Kubernetes Service (AKS)?"",
                ""options"": [
                    ""Managing cloud-based email services"",
                    ""Deploying and managing containerized applications"",
                    ""Storing unstructured data"",
                    ""Automating cost management""
                ]
            },
            {
                ""question_id"": 44,
                ""question"": ""Which Azure compute option provides a Platform as a Service (PaaS) solution?"",
                ""options"": [
                    ""Azure Virtual Machines"",
                    ""Azure Functions"",
                    ""Azure App Service"",
                    ""Azure Blob Storage""
                ]
            },
            {
                ""question_id"": 45,
                ""question"": ""Which type of scaling adds more virtual machines To a system?"",
                ""options"": [
                    ""Vertical scaling"",
                    ""Horizontal scaling"",
                    ""Automatic scaling"",
                    ""Scheduled scaling""
                ]
            },
            {
                ""question_id"": 46,
                ""question"": ""What does Azure DevOps provide?"",
                ""options"": [
                    ""Identity and access management"",
                    ""A set of development tools for CI/CD pipelines"",
                    ""Network security configurations"",
                    ""Cost optimization recommendations""
                ]
            },
            {
                ""question_id"": 47,
                ""question"": ""What does Pay-as-You-G    pricing in Azure mean?"",
                ""options"": [
                    ""Users pay a fixed amount per year"",
                    ""Users are charged based on actual resource usage"",
                    ""Users get unlimited free usage"",
                    ""Users only pay for storage""
                ]
            },
            {
                ""question_id"": 48,
                ""question"": ""What is a benefit of Azure Hybrid Benefit?"",
                ""options"": [
                    ""Discounts for using Microsoft licenses on Azure"",
                    ""Free security services"",
                    ""Unlimited free data transfers"",
                    ""Extended storage capacity""
                ]
            },
            {
                ""question_id"": 49,
                ""question"": ""What is the primary purpose of Azure Reservations?"",
                ""options"": [
                    ""Provide discounts for committing To long-term usage"",
                    ""Secure virtual machines against attacks"",
                    ""Automate application deployment"",
                    ""Enhance database performance""
                ]
            },
            {
                ""question_id"": 50,
                ""question"": ""What is the purpose of an Azure Region?"",
                ""options"": [
                    ""To define a geographical area where Azure resources are deployed"",
                    ""To provide security for virtual networks"",
                    ""To manage user permissions"",
                    ""To store Azure policies""
                ]
            }
        ]";

        const string answersDataJson = @"
        [
            { ""question_id"": 1, ""correct_option"": ""B"" },
            { ""question_id"": 2, ""correct_option"": ""A"" },
            { ""question_id"": 3, ""correct_option"": ""D"" },
            { ""question_id"": 4, ""correct_option"": ""B"" },
            { ""question_id"": 5, ""correct_option"": ""C"" },
            { ""question_id"": 6, ""correct_option"": ""A"" },
            { ""question_id"": 7, ""correct_option"": ""B"" },
            { ""question_id"": 8, ""correct_option"": ""B"" },
            { ""question_id"": 9, ""correct_option"": ""B"" },
            { ""question_id"": 10, ""correct_option"": ""A"" },
            { ""question_id"": 11, ""correct_option"": ""D"" },
            { ""question_id"": 12, ""correct_option"": ""A"" },
            { ""question_id"": 13, ""correct_option"": ""C"" },
            { ""question_id"": 14, ""correct_option"": ""B"" },
            { ""question_id"": 15, ""correct_option"": ""B"" },
            { ""question_id"": 16, ""correct_option"": ""B"" },
            { ""question_id"": 17, ""correct_option"": ""A"" },
            { ""question_id"": 18, ""correct_option"": ""B"" },
            { ""question_id"": 19, ""correct_option"": ""B"" },
            { ""question_id"": 20, ""correct_option"": ""C"" },
            { ""question_id"": 21, ""correct_option"": ""C"" },
            { ""question_id"": 22, ""correct_option"": ""B"" },
            { ""question_id"": 23, ""correct_option"": ""B"" },
            { ""question_id"": 24, ""correct_option"": ""C"" },
            { ""question_id"": 25, ""correct_option"": ""B"" },
            { ""question_id"": 26, ""correct_option"": ""C"" },
            { ""question_id"": 27, ""correct_option"": ""B"" },
            { ""question_id"": 28, ""correct_option"": ""B"" },
            { ""question_id"": 29, ""correct_option"": ""C"" },
            { ""question_id"": 30, ""correct_option"": ""A"" },
            { ""question_id"": 31, ""correct_option"": ""A"" },
            { ""question_id"": 32, ""correct_option"": ""A"" },
            { ""question_id"": 33, ""correct_option"": ""B"" },
            { ""question_id"": 34, ""correct_option"": ""B"" },
            { ""question_id"": 35, ""correct_option"": ""B"" },
            { ""question_id"": 36, ""correct_option"": ""A"" },
            { ""question_id"": 37, ""correct_option"": ""A"" },
            { ""question_id"": 38, ""correct_option"": ""D"" },
            { ""question_id"": 39, ""correct_option"": ""B"" },
            { ""question_id"": 40, ""correct_option"": ""C"" },
            { ""question_id"": 41, ""correct_option"": ""B"" },
            { ""question_id"": 42, ""correct_option"": ""B"" },
            { ""question_id"": 43, ""correct_option"": ""B"" },
            { ""question_id"": 44, ""correct_option"": ""C"" },
            { ""question_id"": 45, ""correct_option"": ""B"" },
            { ""question_id"": 46, ""correct_option"": ""B"" },
            { ""question_id"": 47, ""correct_option"": ""B"" },
            { ""question_id"": 48, ""correct_option"": ""A"" },
            { ""question_id"": 49, ""correct_option"": ""A"" },
            { ""question_id"": 50, ""correct_option"": ""A"" }
        ]";

        static void Main(string[] args)
        {
            List<Question> quizQuestions = JsonSerializer.Deserialize<List<Question>>(quizQuestionsJson);
            List<Answer> answersData = JsonSerializer.Deserialize<List<Answer>>(answersDataJson);

            if (quizQuestions == null || answersData == null || !quizQuestions.Any())
            {
                Console.WriteLine("No quiz questions available.");
                return;
            }

            Random random = new Random();
            int score = 0;
            bool playAgain = true;

            while (playAgain)
            {
                int randomIndex = random.Next(quizQuestions.Count);
                Question currentQuestion = quizQuestions[randomIndex];

                Console.WriteLine($"\nQuestion {currentQuestion.question_id}: {currentQuestion.question}");

                char optionLetter = 'A';
                if (currentQuestion.options != null)
                {
                    foreach (var option in currentQuestion.options)
                    {
                        Console.WriteLine($"{optionLetter}. {option}");
                        optionLetter++;
                    }

                    Console.Write("Your answer (A, B, C, or D): ");
                    string userAnswer = Console.ReadLine()?.ToUpper();

                    Answer correctAnswerObject =
                        answersData.FirstOrDefault(a => a.question_id == currentQuestion.question_id);

                    if (correctAnswerObject != null)
                    {
                        if (!string.IsNullOrEmpty(userAnswer) && userAnswer.Length == 1 && userAnswer[0] >= 'A' &&
                            userAnswer[0] <= 'D')
                        {
                            int selectedIndex = userAnswer[0] - 'A';
                            if (selectedIndex >= 0 && selectedIndex < currentQuestion.options.Count)
                            {
                                string selectedAnswerText = currentQuestion.options[selectedIndex];

                                // Convert user's choice (A, B, C, D) to the correct option format
                                char selectedOptionChar = (char)('A' + selectedIndex);
                                string selectedOption = selectedOptionChar.ToString();

                                if (selectedOption == correctAnswerObject.correct_option)
                                {
                                    Console.WriteLine("Correct!");
                                    score++;
                                }
                                else
                                {
                                    Console.WriteLine(
                                        $"Incorrect. The correct answer was {correctAnswerObject.correct_option}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid option selected. Quiting Quiz!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter A, B, C, or D.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Correct answer not found for this question.");
                    }
                }
            }

            Console.WriteLine($"\nQuiz finished! Your final score is: {score}/{quizQuestions.Count}");
        }
    }
}