﻿using CodeGenConfig;

namespace CodeGenWrapper
{
	public class Wrapper
	{
		public string? PchPath { get; set; }
		public List<string> HeaderFilePaths { get; set; } = new List<string>();

		public void PathsFromConfig(Config config)
		{
			PchPath = config.Pch == null ? null : Path.GetFullPath(config.Pch);
			HeaderFilePaths = config.HeaderDirectories
				.SelectMany(p => Directory.GetFiles(Path.GetFullPath(p), "*.h"))
				.Where(p => p != PchPath)
				.ToList();
		}
	}
}