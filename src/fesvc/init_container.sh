#!/usr/bin/env bash

service nginx start

/app/bin/fesvc $1 $2 $3 $4
