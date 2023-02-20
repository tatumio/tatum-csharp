#!/bin/bash

function kill_and_exit() {
    kill %1 > /dev/null 2>&1
    exit $1
}

dotnet run --project Tatum.CSharp.Demo > .hck_debug 2>&1 &

sleep 3

http_code=$(curl --max-time 5 https://localhost:7285/notification -o /dev/null -k -s -w %{http_code})
code=$?

if [[ $code -ne 0 ]]; then
  echo "Probe failed with error code $code"
  kill_and_exit 1
fi

if [[ $http_code != "200" ]]; then
  echo -e "Endpoint failed with http response code: $http_code\nLog:"
  tail -n 20 .hck_debug
  kill_and_exit 1
else
  echo "SUCCESS"
  kill_and_exit 0
fi