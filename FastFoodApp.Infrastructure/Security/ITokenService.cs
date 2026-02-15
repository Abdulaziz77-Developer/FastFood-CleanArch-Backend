// Moved to FastFoodApp.Core.Security
// This file is kept for backward compatibility
using FastFoodApp.Core.Security;

namespace FastFoodApp.Infrastructure.Security;

// Re-export from Core for backward compatibility
public interface ITokenService : Core.Security.ITokenService { }
