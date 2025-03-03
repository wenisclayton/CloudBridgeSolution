provider "aws" {
  region = var.aws_region
}

resource "aws_sqs_queue" "cloudbridge_queue" {
  name = "cloudbridge-queue"
}
