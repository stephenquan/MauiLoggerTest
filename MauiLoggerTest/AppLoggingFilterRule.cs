using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace MauiLoggerTest;

/// <summary>
/// Represents a logging filter rule that determines whether log messages are included or excluded based on their
/// category and log level.
/// </summary>
/// <remarks>This rule can be used to filter log messages by matching their category against a regular expression
/// and specifying whether the rule is an inclusion or exclusion rule. The log level determines the minimum severity of
/// messages affected by the rule.</remarks>
public class AppLoggingFilterRule
{
	/// <summary>
	/// Gets or sets the regular expression used to match category names.
	/// </summary>
	/// <remarks>Use this property to specify a regular expression for validating or filtering category names.  If
	/// set to <see langword="null"/>, no validation or filtering will be applied.</remarks>
	public required Regex CategoryRegex { get; set; }

	/// <summary>
	/// Gets or sets the logging level for the current logger.
	/// </summary>
	public LogLevel Level { get; set; } = LogLevel.Trace;

	/// <summary>
	/// Converts a wildcard pattern to a <see cref="Regex"/> object.
	/// </summary>
	/// <remarks>This method escapes all characters in the wildcard pattern except for '*' and '?',
	/// which are translated to their regular expression equivalents.
	/// The '^' and '$' characters, if present at the start or end of the pattern, are treated as anchors for the regular expression.</remarks>
	/// <param name="wildcard">The wildcard pattern to convert.
	/// The pattern may include '*' to match zero or more characters and '?' to match a single character.
	/// If the pattern starts with '^', it will anchor the match to the beginning of the input.
	/// If the pattern ends with '$', it will anchor the match to the end of the input.</param>
	/// <returns>A <see cref="Regex"/> object that represents the equivalent regular expression for the given wildcard pattern.
	/// The resulting <see cref="Regex"/> is case-insensitive and culture-invariant.</returns>
	public static Regex WildcardToRegex(string wildcard)
	{
		string prefix = string.Empty;
		if (wildcard.StartsWith("^"))
		{
			prefix = "^";
			wildcard = wildcard.Substring(1);
		}

		string suffix = string.Empty;
		if (wildcard.EndsWith("$"))
		{
			suffix = "$";
			wildcard = wildcard.Substring(0, wildcard.Length - 1);
		}

		string pattern = Regex.Escape(wildcard)
			.Replace("\\*", ".*")
			.Replace("\\?", ".");

		return new Regex(prefix + pattern + suffix, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
	}

	/// <summary>
	/// Creates an instance of <see cref="AppLoggingFilterRule"/> based on the specified rule string.
	/// </summary>
	/// <remarks>The method interprets the rule string as follows:
	/// <list type="bullet">
	/// <item> <description>If the rule starts with "!", it creates a rule that excludes the specified category, with a log level of <see
	/// cref="LogLevel.None"/>.</description> </item>
	/// <item> <description>If the rule contains "=", it splits the string into a category and a log level.
	/// The log level is parsed as a <see cref="LogLevel"/> enumeration value.</description> </item>
	/// <item> <description>If the rule contains only a category, it defaults to a log level of <see cref="LogLevel.Trace"/>.</description> </item>
	/// </list></remarks>
	/// <param name="rule">A string representing the logging filter rule.
	/// The rule can specify a category and log level in the format "Category=Level", a negated category using "!", or just a category.
	/// If the rule is null or empty, the method returns <see langword="null"/>.</param>
	/// <returns>An instance of <see cref="AppLoggingFilterRule"/> configured according to the specified rule,
	/// or <see langword="null"/> if the rule is invalid or empty.</returns>
	public static AppLoggingFilterRule? CreateAsync(string rule)
	{
		if (string.IsNullOrEmpty(rule))
		{
			return null;
		}

		if (rule.StartsWith("!"))
		{
			return new AppLoggingFilterRule
			{
				CategoryRegex = WildcardToRegex(rule.Substring(1)),
				Level = LogLevel.None
			};
		}

		var parts = rule.Split('=', 2);
		if (parts.Length == 2)
		{
			return new AppLoggingFilterRule
			{
				CategoryRegex = WildcardToRegex(parts[0]),
				Level = Enum.Parse<LogLevel>(parts[1], true)
			};
		}

		if (parts.Length == 1)
		{
			return new AppLoggingFilterRule
			{
				CategoryRegex = WildcardToRegex(parts[0]),
				Level = LogLevel.Trace
			};
		}

		return null;
	}
}
