provider "google" {
  project = var.gcp_project
  region  = var.gcp_region
}

resource "google_pubsub_topic" "cloudbridge_topic" {
  name = "cloudbridge-topic"
}

resource "google_pubsub_subscription" "cloudbridge_subscription" {
  name  = "cloudbridge-subscription"
  topic = google_pubsub_topic.cloudbridge_topic.name
}
