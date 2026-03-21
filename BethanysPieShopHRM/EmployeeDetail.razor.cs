// ❌ This won't load Country
var employee = await _context.Employees.FindAsync(EmployeeId);

// ✅ This will load Country
var employee = await _context.Employees
    .Include(e => e.Country)
    .FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);