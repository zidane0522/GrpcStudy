setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=packages\Grpc.Tools.1.2.0\tools\windows_x86

%TOOLS_PATH%\protoc.exe -I../../protos --csharp_out GrpcLib  ../../protos/helloworld.proto --grpc_out GrpcLib --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe

endlocal
