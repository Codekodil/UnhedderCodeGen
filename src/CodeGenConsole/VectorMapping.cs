using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Generators;
using CppSharp.Generators.CSharp;
using CppSharp.Types;
using System.Numerics;

namespace CodeGenConsole
{
	[TypeMap("glm::vec2", GeneratorKind = GeneratorKind.CSharp)]
	public class Vec2Mapping : VectorMapping<Vector2> { }

	[TypeMap("glm::vec3", GeneratorKind = GeneratorKind.CSharp)]
	public class Vec3Mapping : VectorMapping<Vector3> { }

	[TypeMap("glm::vec4", GeneratorKind = GeneratorKind.CSharp)]
	public class Vec4Mapping : VectorMapping<Vector4> { }

	public class VectorMapping<TVec> : TypeMap
	{
		public override bool IsValueType => true;
		public override CppSharp.AST.Type CSharpSignatureType(TypePrinterContext ctx)
		{
			if (ctx.Parameter?.IsIndirect == false && ctx.Parameter.Type.IsPointer() == true)
				ctx.Parameter.Usage = ParameterUsage.InOut;
			return new CILType(typeof(TVec));
		}

		public override void CSharpMarshalToNative(CSharpMarshalContext ctx)
		{
			if (ctx.Parameter == null)
				throw new NotImplementedException();

			if (ctx.Parameter.Type.IsPointer())
			{
				if (ctx.Parameter.IsIndirect)
				{
					ctx.Return.Write($"(__IntPtr)(&{ctx.Parameter.Name})");
				}
				else
				{
					var local = Generator.GeneratedIdentifier($"{ctx.Parameter.Name}{ctx.ParameterIndex}");
					ctx.Before.WriteLine($"fixed ({ctx.Parameter.Type}* {local} = &{ctx.Parameter.Name})");
					ctx.HasCodeBlock = true;
					ctx.Before.WriteOpenBraceAndIndent();
					ctx.Return.Write($"(__IntPtr){local}");
				}
			}
			else
			{
				ctx.Return.Write(ctx.Parameter.Name);
			}
		}
	}
}
