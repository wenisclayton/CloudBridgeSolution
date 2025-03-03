variable "provider_selected" {
  description = "Provedor de mensageria selecionado pela aplicação: aws, gcp, azure ou rabbitmq"
  type        = string
}

variable "aws_region" {
  description = "Região para provisionar recursos na AWS"
  type        = string
}

variable "gcp_project" {
  description = "Projeto no GCP"
  type        = string
}

variable "gcp_region" {
  description = "Região do GCP"
  type        = string
}

variable "azure_location" {
  description = "Localização dos recursos no Azure"
  type        = string
}

variable "azure_resource_group" {
  description = "Nome do grupo de recursos no Azure"
  type        = string
}

# variable "rabbitmq_endpoint" {
#   description = "Endpoint do RabbitMQ"
#   type        = string
# }

# variable "rabbitmq_username" {
#   description = "Usuário do RabbitMQ"
#   type        = string
# }
# 
# variable "rabbitmq_password" {
#   description = "Senha do RabbitMQ"
#   type        = string
#   sensitive   = true
# }