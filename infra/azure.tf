provider "azurerm" {
  features {}
}

resource "azurerm_servicebus_namespace" "cloudbridge_namespace" {
  name                = "cloudbridge-namespace"
  location            = var.azure_location
  resource_group_name = var.azure_resource_group
  sku                 = "Standard"
}

resource "azurerm_servicebus_queue" "cloudbridge_queue" {
  name         = "cloudbridge-queue"
  namespace_id = azurerm_servicebus_namespace.cloudbridge_namespace.id
}