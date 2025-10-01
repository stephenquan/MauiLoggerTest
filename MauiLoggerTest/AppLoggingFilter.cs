
using Microsoft.Extensions.Logging;

namespace MauiLoggerTest;

/// <summary>
/// Provides functionality to filter logging categories based on configurable rules.
/// </summary>
/// <remarks>The <see cref="AppLoggingFilter"/> class allows filtering of log messages by matching their
/// categories against a set of rules.
/// Rules are defined as a semicolon-separated string, where each rule can be a regular expression.
/// Rules prefixed with "!" act as exclusion filters.</remarks>
public class AppLoggingFilter
{
	/// <summary>
	/// Gets the current instance of the <see cref="AppLoggingFilter"/> used for application-wide logging configuration.
	/// </summary>
	public static AppLoggingFilter Current { get; } = new AppLoggingFilter();

	string rules = string.Empty;

	/// <summary>
	/// Gets or sets the rules or guidelines associated with the current context.
	/// </summary>
	public string Rules
	{
		get => rules;
		set
		{
			rules = value;
			compiled = false;
		}
	}

	bool compiled = false;

	List<AppLoggingFilterRule> CompiledRules { get; } = new(0);

	/// <summary>
	/// Determines whether a log entry with the specified category and log level should be processed based on the
	/// current logging filter rules.
	/// </summary>
	/// <remarks>The filtering logic is based on a set of rules defined in <see
	/// cref="Rules"/>. Rules are semicolon-separated strings, and each rule can optionally
	/// start with an exclamation mark ('!') to indicate exclusion. Regular expressions are used to match the category
	/// against the rules. <para> If no rules are defined or the category is <see langword="null"/> or empty, the method
	/// returns <see langword="false"/>. </para></remarks>
	/// <param name="category">The category of the log entry. Cannot be <see langword="null"/> or empty.</param>
	/// <param name="level">The log level of the log entry.</param>
	/// <returns><see langword="true"/> if the log entry matches the current filter rules and should be processed; otherwise,
	/// <see langword="false"/>.</returns>
	public bool DefaultFilter(string? category, LogLevel level)
	{
		bool result = false;

		if (string.IsNullOrEmpty(category))
		{
			return result;
		}

		if (!compiled)
		{
			CompiledRules.Clear();
			foreach (string rule in AppLoggingFilter.Current.Rules.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
			{
				try
				{
					if (AppLoggingFilterRule.CreateAsync(rule) is AppLoggingFilterRule compiledRule)
					{
						CompiledRules.Add(compiledRule);
					}
				}
				catch (Exception ex)
				{
					System.Diagnostics.Trace.WriteLine($"Error compiling rule '{rule}': {ex.Message}");
				}
			}
			compiled = true;
		}

		foreach (var rule in CompiledRules)
		{
			if (rule.CategoryRegex.Match(category).Success)
			{
				result = level >= rule.Level;
			}
		}

		return result;
	}
}
