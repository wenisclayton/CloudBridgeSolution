terraform {
  required_version = ">= 1.0.0"

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 4.0"
    }
    google = {
      source  = "hashicorp/google"
      version = "~> 4.0"
    }
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
    # rabbitmq = {
    #   source  = "rabbitmq/rabbitmq"
    #   version = "~> 1.0"
    # }
  }

  # Se você tiver um backend para armazenar o estado, configure-o aqui
  # backend "s3" {
  #   bucket = "meu-bucket-de-estado"
  #   key    = "terraform/state"
  #   region = "us-east-1"
  # }
}
