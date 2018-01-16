﻿using PowerBi.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerBi.Tests
{
    public class MetadataConverterTest
    {
        [Fact]
        public void Test1()
        {
            var fileSystem = new MockFileSystem();
            var conv = new MetadataConverter(Encoding.UTF8,fileSystem);
            var filePath = @"c:\Test\Metadata";
            var data = new byte[] { 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x05, 0x44, 0x41, 0x54, 0x45, 0x53, 0x24, 0x35, 0x37, 0x33, 0x65, 0x66, 0x62, 0x31, 0x34, 0x2D, 0x36, 0x30, 0x33, 0x33, 0x2D, 0x34, 0x36, 0x61, 0x61, 0x2D, 0x38, 0x34, 0x63, 0x36, 0x2D, 0x37, 0x64, 0x33, 0x38, 0x35, 0x39, 0x38, 0x39, 0x62, 0x61, 0x61, 0x62, 0x12, 0x46, 0x4F, 0x52, 0x4D, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x53, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x66, 0x66, 0x66, 0x64, 0x37, 0x31, 0x63, 0x30, 0x2D, 0x31, 0x37, 0x66, 0x61, 0x2D, 0x34, 0x62, 0x64, 0x35, 0x2D, 0x62, 0x38, 0x31, 0x65, 0x2D, 0x30, 0x30, 0x32, 0x64, 0x37, 0x32, 0x63, 0x34, 0x38, 0x30, 0x32, 0x30, 0x12, 0x48, 0x49, 0x53, 0x54, 0x4F, 0x52, 0x49, 0x51, 0x55, 0x45, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x34, 0x31, 0x39, 0x39, 0x65, 0x63, 0x30, 0x62, 0x2D, 0x66, 0x33, 0x32, 0x36, 0x2D, 0x34, 0x33, 0x30, 0x66, 0x2D, 0x39, 0x35, 0x63, 0x36, 0x2D, 0x31, 0x37, 0x62, 0x66, 0x39, 0x38, 0x33, 0x35, 0x34, 0x31, 0x31, 0x37, 0x3B, 0x54, 0x72, 0x61, 0x6E, 0x73, 0x66, 0x6F, 0x72, 0x6D, 0x65, 0x72, 0x20, 0x6C, 0x27, 0x65, 0x78, 0x65, 0x6D, 0x70, 0x6C, 0x65, 0x20, 0x64, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x20, 0xC3, 0xA0, 0x20, 0x70, 0x61, 0x72, 0x74, 0x69, 0x72, 0x20, 0x64, 0x65, 0x20, 0x46, 0x49, 0x43, 0x48, 0x49, 0x45, 0x52, 0x53, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x24, 0x31, 0x32, 0x33, 0x65, 0x61, 0x32, 0x34, 0x33, 0x2D, 0x37, 0x37, 0x63, 0x33, 0x2D, 0x34, 0x39, 0x39, 0x61, 0x2D, 0x38, 0x33, 0x34, 0x38, 0x2D, 0x61, 0x37, 0x37, 0x39, 0x39, 0x34, 0x32, 0x63, 0x65, 0x36, 0x30, 0x61, 0x23, 0x50, 0x61, 0x72, 0x61, 0x6D, 0xC3, 0xA8, 0x74, 0x72, 0x65, 0x20, 0x64, 0x65, 0x20, 0x6C, 0x27, 0x65, 0x78, 0x65, 0x6D, 0x70, 0x6C, 0x65, 0x20, 0x64, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x31, 0x24, 0x36, 0x65, 0x37, 0x37, 0x66, 0x37, 0x66, 0x63, 0x2D, 0x32, 0x30, 0x64, 0x66, 0x2D, 0x34, 0x63, 0x31, 0x61, 0x2D, 0x62, 0x32, 0x62, 0x34, 0x2D, 0x62, 0x39, 0x37, 0x64, 0x65, 0x35, 0x65, 0x64, 0x36, 0x34, 0x39, 0x33, 0x12, 0x45, 0x78, 0x65, 0x6D, 0x70, 0x6C, 0x65, 0x20, 0x64, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x24, 0x36, 0x63, 0x30, 0x63, 0x64, 0x32, 0x34, 0x62, 0x2D, 0x38, 0x61, 0x30, 0x37, 0x2D, 0x34, 0x38, 0x30, 0x66, 0x2D, 0x39, 0x38, 0x31, 0x32, 0x2D, 0x62, 0x66, 0x66, 0x64, 0x61, 0x64, 0x37, 0x34, 0x35, 0x30, 0x37, 0x35, 0x31, 0x54, 0x72, 0x61, 0x6E, 0x73, 0x66, 0x6F, 0x72, 0x6D, 0x65, 0x72, 0x20, 0x6C, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x20, 0xC3, 0xA0, 0x20, 0x70, 0x61, 0x72, 0x74, 0x69, 0x72, 0x20, 0x64, 0x65, 0x20, 0x46, 0x49, 0x43, 0x48, 0x49, 0x45, 0x52, 0x53, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x24, 0x37, 0x39, 0x30, 0x38, 0x66, 0x61, 0x32, 0x34, 0x2D, 0x66, 0x63, 0x61, 0x65, 0x2D, 0x34, 0x37, 0x61, 0x30, 0x2D, 0x61, 0x63, 0x36, 0x35, 0x2D, 0x37, 0x33, 0x35, 0x37, 0x30, 0x30, 0x38, 0x62, 0x32, 0x34, 0x38, 0x66, 0x10, 0x41, 0x42, 0x53, 0x45, 0x4E, 0x43, 0x45, 0x53, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x35, 0x30, 0x66, 0x33, 0x38, 0x63, 0x35, 0x63, 0x2D, 0x62, 0x32, 0x66, 0x62, 0x2D, 0x34, 0x62, 0x30, 0x32, 0x2D, 0x39, 0x31, 0x62, 0x38, 0x2D, 0x63, 0x33, 0x38, 0x63, 0x30, 0x63, 0x62, 0x65, 0x32, 0x31, 0x33, 0x61, 0x11, 0x41, 0x43, 0x54, 0x49, 0x56, 0x49, 0x54, 0x45, 0x53, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x63, 0x34, 0x64, 0x36, 0x32, 0x31, 0x39, 0x32, 0x2D, 0x38, 0x65, 0x32, 0x61, 0x2D, 0x34, 0x38, 0x64, 0x38, 0x2D, 0x62, 0x38, 0x33, 0x34, 0x2D, 0x62, 0x39, 0x63, 0x36, 0x65, 0x38, 0x33, 0x37, 0x34, 0x34, 0x37, 0x65, 0x17, 0x31, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x45, 0x46, 0x46, 0x45, 0x43, 0x54, 0x49, 0x46, 0x53, 0x24, 0x39, 0x62, 0x37, 0x62, 0x62, 0x66, 0x62, 0x36, 0x2D, 0x39, 0x32, 0x33, 0x32, 0x2D, 0x34, 0x31, 0x33, 0x30, 0x2D, 0x61, 0x39, 0x34, 0x32, 0x2D, 0x66, 0x39, 0x66, 0x62, 0x31, 0x35, 0x38, 0x33, 0x37, 0x30, 0x35, 0x35, 0x15, 0x54, 0x45, 0x4D, 0x50, 0x53, 0x5F, 0x54, 0x52, 0x41, 0x56, 0x41, 0x49, 0x4C, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x63, 0x33, 0x61, 0x30, 0x32, 0x64, 0x64, 0x36, 0x2D, 0x37, 0x63, 0x30, 0x64, 0x2D, 0x34, 0x34, 0x63, 0x39, 0x2D, 0x38, 0x64, 0x33, 0x36, 0x2D, 0x35, 0x32, 0x37, 0x64, 0x35, 0x34, 0x62, 0x30, 0x35, 0x31, 0x30, 0x39, 0x14, 0x52, 0x45, 0x4D, 0x55, 0x4E, 0x45, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x32, 0x36, 0x31, 0x65, 0x30, 0x31, 0x39, 0x39, 0x2D, 0x37, 0x62, 0x34, 0x39, 0x2D, 0x34, 0x63, 0x33, 0x63, 0x2D, 0x38, 0x33, 0x64, 0x39, 0x2D, 0x61, 0x33, 0x62, 0x66, 0x65, 0x38, 0x64, 0x66, 0x36, 0x37, 0x61, 0x34, 0x21, 0x45, 0x72, 0x72, 0x65, 0x75, 0x72, 0x73, 0x20, 0x64, 0x61, 0x6E, 0x73, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x4E, 0x45, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x30, 0x63, 0x32, 0x64, 0x35, 0x63, 0x66, 0x63, 0x2D, 0x34, 0x32, 0x62, 0x33, 0x2D, 0x34, 0x39, 0x30, 0x33, 0x2D, 0x38, 0x34, 0x62, 0x66, 0x2D, 0x34, 0x63, 0x35, 0x38, 0x64, 0x62, 0x39, 0x34, 0x38, 0x38, 0x64, 0x64, 0x10, 0x73, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x73, 0x71, 0x6C, 0x20, 0x73, 0x65, 0x75, 0x6C, 0x65, 0x24, 0x62, 0x34, 0x32, 0x32, 0x33, 0x31, 0x32, 0x62, 0x2D, 0x37, 0x36, 0x38, 0x34, 0x2D, 0x34, 0x34, 0x36, 0x63, 0x2D, 0x38, 0x62, 0x37, 0x34, 0x2D, 0x34, 0x65, 0x62, 0x32, 0x65, 0x31, 0x30, 0x36, 0x64, 0x34, 0x34, 0x34, 0x1A, 0x32, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x4E, 0x45, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x24, 0x35, 0x65, 0x38, 0x37, 0x35, 0x35, 0x36, 0x65, 0x2D, 0x39, 0x37, 0x62, 0x33, 0x2D, 0x34, 0x61, 0x66, 0x35, 0x2D, 0x62, 0x63, 0x64, 0x63, 0x2D, 0x61, 0x62, 0x61, 0x36, 0x33, 0x34, 0x34, 0x37, 0x61, 0x34, 0x33, 0x33, 0x18, 0x33, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x4D, 0x4F, 0x55, 0x56, 0x45, 0x4D, 0x45, 0x4E, 0x54, 0x53, 0x24, 0x39, 0x34, 0x39, 0x32, 0x31, 0x38, 0x62, 0x33, 0x2D, 0x66, 0x65, 0x30, 0x61, 0x2D, 0x34, 0x64, 0x35, 0x66, 0x2D, 0x61, 0x62, 0x63, 0x63, 0x2D, 0x33, 0x30, 0x38, 0x37, 0x37, 0x33, 0x61, 0x33, 0x34, 0x31, 0x32, 0x39, 0x17, 0x34, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x46, 0x4F, 0x52, 0x4D, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x24, 0x64, 0x65, 0x36, 0x36, 0x63, 0x36, 0x36, 0x65, 0x2D, 0x39, 0x33, 0x63, 0x37, 0x2D, 0x34, 0x34, 0x64, 0x66, 0x2D, 0x62, 0x65, 0x30, 0x31, 0x2D, 0x32, 0x39, 0x39, 0x33, 0x61, 0x36, 0x62, 0x39, 0x31, 0x33, 0x33, 0x64, 0x17, 0x35, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x44, 0x41, 0x53, 0x48, 0x42, 0x4F, 0x41, 0x52, 0x44, 0x24, 0x64, 0x66, 0x64, 0x64, 0x30, 0x32, 0x31, 0x35, 0x2D, 0x33, 0x61, 0x35, 0x37, 0x2D, 0x34, 0x38, 0x34, 0x30, 0x2D, 0x61, 0x38, 0x35, 0x31, 0x2D, 0x31, 0x33, 0x34, 0x37, 0x31, 0x33, 0x65, 0x31, 0x38, 0x37, 0x33, 0x31, 0x1B, 0x36, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x5F, 0x54, 0x45, 0x4D, 0x50, 0x53, 0x5F, 0x54, 0x52, 0x41, 0x56, 0x41, 0x49, 0x4C, 0x24, 0x64, 0x38, 0x64, 0x38, 0x61, 0x37, 0x65, 0x62, 0x2D, 0x38, 0x30, 0x39, 0x30, 0x2D, 0x34, 0x33, 0x62, 0x35, 0x2D, 0x38, 0x66, 0x32, 0x34, 0x2D, 0x61, 0x66, 0x33, 0x39, 0x39, 0x63, 0x32, 0x66, 0x39, 0x62, 0x33, 0x63, 0x13, 0x00, 0x00, 0x00, 0x24, 0x35, 0x37, 0x33, 0x65, 0x66, 0x62, 0x31, 0x34, 0x2D, 0x36, 0x30, 0x33, 0x33, 0x2D, 0x34, 0x36, 0x61, 0x61, 0x2D, 0x38, 0x34, 0x63, 0x36, 0x2D, 0x37, 0x64, 0x33, 0x38, 0x35, 0x39, 0x38, 0x39, 0x62, 0x61, 0x61, 0x62, 0x05, 0x44, 0x41, 0x54, 0x45, 0x53, 0x24, 0x66, 0x66, 0x66, 0x64, 0x37, 0x31, 0x63, 0x30, 0x2D, 0x31, 0x37, 0x66, 0x61, 0x2D, 0x34, 0x62, 0x64, 0x35, 0x2D, 0x62, 0x38, 0x31, 0x65, 0x2D, 0x30, 0x30, 0x32, 0x64, 0x37, 0x32, 0x63, 0x34, 0x38, 0x30, 0x32, 0x30, 0x12, 0x46, 0x4F, 0x52, 0x4D, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x53, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x34, 0x31, 0x39, 0x39, 0x65, 0x63, 0x30, 0x62, 0x2D, 0x66, 0x33, 0x32, 0x36, 0x2D, 0x34, 0x33, 0x30, 0x66, 0x2D, 0x39, 0x35, 0x63, 0x36, 0x2D, 0x31, 0x37, 0x62, 0x66, 0x39, 0x38, 0x33, 0x35, 0x34, 0x31, 0x31, 0x37, 0x12, 0x48, 0x49, 0x53, 0x54, 0x4F, 0x52, 0x49, 0x51, 0x55, 0x45, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x31, 0x32, 0x33, 0x65, 0x61, 0x32, 0x34, 0x33, 0x2D, 0x37, 0x37, 0x63, 0x33, 0x2D, 0x34, 0x39, 0x39, 0x61, 0x2D, 0x38, 0x33, 0x34, 0x38, 0x2D, 0x61, 0x37, 0x37, 0x39, 0x39, 0x34, 0x32, 0x63, 0x65, 0x36, 0x30, 0x61, 0x3B, 0x54, 0x72, 0x61, 0x6E, 0x73, 0x66, 0x6F, 0x72, 0x6D, 0x65, 0x72, 0x20, 0x6C, 0x27, 0x65, 0x78, 0x65, 0x6D, 0x70, 0x6C, 0x65, 0x20, 0x64, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x20, 0xC3, 0xA0, 0x20, 0x70, 0x61, 0x72, 0x74, 0x69, 0x72, 0x20, 0x64, 0x65, 0x20, 0x46, 0x49, 0x43, 0x48, 0x49, 0x45, 0x52, 0x53, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x24, 0x36, 0x65, 0x37, 0x37, 0x66, 0x37, 0x66, 0x63, 0x2D, 0x32, 0x30, 0x64, 0x66, 0x2D, 0x34, 0x63, 0x31, 0x61, 0x2D, 0x62, 0x32, 0x62, 0x34, 0x2D, 0x62, 0x39, 0x37, 0x64, 0x65, 0x35, 0x65, 0x64, 0x36, 0x34, 0x39, 0x33, 0x23, 0x50, 0x61, 0x72, 0x61, 0x6D, 0xC3, 0xA8, 0x74, 0x72, 0x65, 0x20, 0x64, 0x65, 0x20, 0x6C, 0x27, 0x65, 0x78, 0x65, 0x6D, 0x70, 0x6C, 0x65, 0x20, 0x64, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x31, 0x24, 0x36, 0x63, 0x30, 0x63, 0x64, 0x32, 0x34, 0x62, 0x2D, 0x38, 0x61, 0x30, 0x37, 0x2D, 0x34, 0x38, 0x30, 0x66, 0x2D, 0x39, 0x38, 0x31, 0x32, 0x2D, 0x62, 0x66, 0x66, 0x64, 0x61, 0x64, 0x37, 0x34, 0x35, 0x30, 0x37, 0x35, 0x12, 0x45, 0x78, 0x65, 0x6D, 0x70, 0x6C, 0x65, 0x20, 0x64, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x24, 0x37, 0x39, 0x30, 0x38, 0x66, 0x61, 0x32, 0x34, 0x2D, 0x66, 0x63, 0x61, 0x65, 0x2D, 0x34, 0x37, 0x61, 0x30, 0x2D, 0x61, 0x63, 0x36, 0x35, 0x2D, 0x37, 0x33, 0x35, 0x37, 0x30, 0x30, 0x38, 0x62, 0x32, 0x34, 0x38, 0x66, 0x31, 0x54, 0x72, 0x61, 0x6E, 0x73, 0x66, 0x6F, 0x72, 0x6D, 0x65, 0x72, 0x20, 0x6C, 0x65, 0x20, 0x66, 0x69, 0x63, 0x68, 0x69, 0x65, 0x72, 0x20, 0xC3, 0xA0, 0x20, 0x70, 0x61, 0x72, 0x74, 0x69, 0x72, 0x20, 0x64, 0x65, 0x20, 0x46, 0x49, 0x43, 0x48, 0x49, 0x45, 0x52, 0x53, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x24, 0x35, 0x30, 0x66, 0x33, 0x38, 0x63, 0x35, 0x63, 0x2D, 0x62, 0x32, 0x66, 0x62, 0x2D, 0x34, 0x62, 0x30, 0x32, 0x2D, 0x39, 0x31, 0x62, 0x38, 0x2D, 0x63, 0x33, 0x38, 0x63, 0x30, 0x63, 0x62, 0x65, 0x32, 0x31, 0x33, 0x61, 0x10, 0x41, 0x42, 0x53, 0x45, 0x4E, 0x43, 0x45, 0x53, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x63, 0x34, 0x64, 0x36, 0x32, 0x31, 0x39, 0x32, 0x2D, 0x38, 0x65, 0x32, 0x61, 0x2D, 0x34, 0x38, 0x64, 0x38, 0x2D, 0x62, 0x38, 0x33, 0x34, 0x2D, 0x62, 0x39, 0x63, 0x36, 0x65, 0x38, 0x33, 0x37, 0x34, 0x34, 0x37, 0x65, 0x11, 0x41, 0x43, 0x54, 0x49, 0x56, 0x49, 0x54, 0x45, 0x53, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x39, 0x62, 0x37, 0x62, 0x62, 0x66, 0x62, 0x36, 0x2D, 0x39, 0x32, 0x33, 0x32, 0x2D, 0x34, 0x31, 0x33, 0x30, 0x2D, 0x61, 0x39, 0x34, 0x32, 0x2D, 0x66, 0x39, 0x66, 0x62, 0x31, 0x35, 0x38, 0x33, 0x37, 0x30, 0x35, 0x35, 0x17, 0x31, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x45, 0x46, 0x46, 0x45, 0x43, 0x54, 0x49, 0x46, 0x53, 0x24, 0x63, 0x33, 0x61, 0x30, 0x32, 0x64, 0x64, 0x36, 0x2D, 0x37, 0x63, 0x30, 0x64, 0x2D, 0x34, 0x34, 0x63, 0x39, 0x2D, 0x38, 0x64, 0x33, 0x36, 0x2D, 0x35, 0x32, 0x37, 0x64, 0x35, 0x34, 0x62, 0x30, 0x35, 0x31, 0x30, 0x39, 0x15, 0x54, 0x45, 0x4D, 0x50, 0x53, 0x5F, 0x54, 0x52, 0x41, 0x56, 0x41, 0x49, 0x4C, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x32, 0x36, 0x31, 0x65, 0x30, 0x31, 0x39, 0x39, 0x2D, 0x37, 0x62, 0x34, 0x39, 0x2D, 0x34, 0x63, 0x33, 0x63, 0x2D, 0x38, 0x33, 0x64, 0x39, 0x2D, 0x61, 0x33, 0x62, 0x66, 0x65, 0x38, 0x64, 0x66, 0x36, 0x37, 0x61, 0x34, 0x14, 0x52, 0x45, 0x4D, 0x55, 0x4E, 0x45, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x30, 0x63, 0x32, 0x64, 0x35, 0x63, 0x66, 0x63, 0x2D, 0x34, 0x32, 0x62, 0x33, 0x2D, 0x34, 0x39, 0x30, 0x33, 0x2D, 0x38, 0x34, 0x62, 0x66, 0x2D, 0x34, 0x63, 0x35, 0x38, 0x64, 0x62, 0x39, 0x34, 0x38, 0x38, 0x64, 0x64, 0x21, 0x45, 0x72, 0x72, 0x65, 0x75, 0x72, 0x73, 0x20, 0x64, 0x61, 0x6E, 0x73, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x4E, 0x45, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x5F, 0x53, 0x41, 0x4C, 0x41, 0x52, 0x49, 0x45, 0x24, 0x62, 0x34, 0x32, 0x32, 0x33, 0x31, 0x32, 0x62, 0x2D, 0x37, 0x36, 0x38, 0x34, 0x2D, 0x34, 0x34, 0x36, 0x63, 0x2D, 0x38, 0x62, 0x37, 0x34, 0x2D, 0x34, 0x65, 0x62, 0x32, 0x65, 0x31, 0x30, 0x36, 0x64, 0x34, 0x34, 0x34, 0x10, 0x73, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x73, 0x71, 0x6C, 0x20, 0x73, 0x65, 0x75, 0x6C, 0x65, 0x24, 0x35, 0x65, 0x38, 0x37, 0x35, 0x35, 0x36, 0x65, 0x2D, 0x39, 0x37, 0x62, 0x33, 0x2D, 0x34, 0x61, 0x66, 0x35, 0x2D, 0x62, 0x63, 0x64, 0x63, 0x2D, 0x61, 0x62, 0x61, 0x36, 0x33, 0x34, 0x34, 0x37, 0x61, 0x34, 0x33, 0x33, 0x1A, 0x32, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x52, 0x45, 0x4D, 0x55, 0x4E, 0x45, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x24, 0x39, 0x34, 0x39, 0x32, 0x31, 0x38, 0x62, 0x33, 0x2D, 0x66, 0x65, 0x30, 0x61, 0x2D, 0x34, 0x64, 0x35, 0x66, 0x2D, 0x61, 0x62, 0x63, 0x63, 0x2D, 0x33, 0x30, 0x38, 0x37, 0x37, 0x33, 0x61, 0x33, 0x34, 0x31, 0x32, 0x39, 0x18, 0x33, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x4D, 0x4F, 0x55, 0x56, 0x45, 0x4D, 0x45, 0x4E, 0x54, 0x53, 0x24, 0x64, 0x65, 0x36, 0x36, 0x63, 0x36, 0x36, 0x65, 0x2D, 0x39, 0x33, 0x63, 0x37, 0x2D, 0x34, 0x34, 0x64, 0x66, 0x2D, 0x62, 0x65, 0x30, 0x31, 0x2D, 0x32, 0x39, 0x39, 0x33, 0x61, 0x36, 0x62, 0x39, 0x31, 0x33, 0x33, 0x64, 0x17, 0x34, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x46, 0x4F, 0x52, 0x4D, 0x41, 0x54, 0x49, 0x4F, 0x4E, 0x24, 0x64, 0x66, 0x64, 0x64, 0x30, 0x32, 0x31, 0x35, 0x2D, 0x33, 0x61, 0x35, 0x37, 0x2D, 0x34, 0x38, 0x34, 0x30, 0x2D, 0x61, 0x38, 0x35, 0x31, 0x2D, 0x31, 0x33, 0x34, 0x37, 0x31, 0x33, 0x65, 0x31, 0x38, 0x37, 0x33, 0x31, 0x17, 0x35, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x20, 0x44, 0x41, 0x53, 0x48, 0x42, 0x4F, 0x41, 0x52, 0x44, 0x24, 0x64, 0x38, 0x64, 0x38, 0x61, 0x37, 0x65, 0x62, 0x2D, 0x38, 0x30, 0x39, 0x30, 0x2D, 0x34, 0x33, 0x62, 0x35, 0x2D, 0x38, 0x66, 0x32, 0x34, 0x2D, 0x61, 0x66, 0x33, 0x39, 0x39, 0x63, 0x32, 0x66, 0x39, 0x62, 0x33, 0x63, 0x1B, 0x36, 0x5F, 0x4D, 0x54, 0x34, 0x5F, 0x4D, 0x45, 0x53, 0x55, 0x52, 0x45, 0x53, 0x5F, 0x54, 0x45, 0x4D, 0x50, 0x53, 0x5F, 0x54, 0x52, 0x41, 0x56, 0x41, 0x49, 0x4C, 0x00, 0x01, 0x05, 0x43, 0x6C, 0x6F, 0x75, 0x64, 0x01, 0x07, 0x32, 0x30, 0x31, 0x38, 0x2E, 0x30, 0x31 };
            var fileData = new MockFileData(data);
            fileSystem.AddFile(filePath, fileData);
            var b = fileSystem.File.Open(filePath,FileMode.Open);
            var o = conv.RawToVcs(b);
            o.Seek(0, SeekOrigin.Begin);
            var b2 = conv.VcsToRaw(o);

            for(var i =0;i<data.Length;i++)
            {
                if(b2.ReadByte() != data[i])
                {
                    throw new Exception(string.Format("Metadata from vcs is not correct at position {0}",i));
                }
            }
        }
    }
}