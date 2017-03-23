setlocal
cd /d %~dp0
@rem enter this directory

set TOOLS_PATH=D:\YuanYing\Mine\grpc\grpc\packages\Grpc.Tools.1.2.0\tools\windows_x86

%TOOLS_PATH%\protoc.exe -ID:\YuanYing\Mine\grpc\grpc\GrpcLib\protos --csharp_out GrpcLib --grpc_out GrpcLib --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe D:\YuanYing\Mine\grpc\grpc\GrpcLib\protos\HelloWorld.proto

endlocal
