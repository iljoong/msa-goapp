#!/usr/bin/env bash
echo "deploying ACS..."

acs-engine deploy --subscription-id <subs_id> \
    --dns-prefix <prefix> \
    --resource-group <rgname> --location <loc> \
    --auto-suffix --api-model ./kubernetes.json \
    --auth-method client_secret \
    --client-id <client_id> \
    --client-secret <client_key>
