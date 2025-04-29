#!/bin/bash

/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'YourStrong!Passw0rd' -C -d master -i /docker-entrypoint-initdb.d/scriptOFICIALsgtcc.sql
