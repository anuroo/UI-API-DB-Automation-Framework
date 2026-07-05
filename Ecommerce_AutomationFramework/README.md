# Ecommerce Automation Framework

## Overview
Hybrid automation framework for UI, API, and database validation.

## Structure
- Core: config, DI, factories
- API: request builders, services, models
- UI: driver, pages, flows
- Database: DB helpers and repositories
- Tests: grouped by API/UI/DB/E2E

## Run
dotnet test

## Categories
Smoke, Regression, Negative, Integration, E2E

## Phase 0 Completed Changes
Phase 0 was focused on creating a clean, interview-ready baseline framework skeleton without overengineering.

### Core
- Added `TestSettings` as a strongly typed configuration model.
- Added `SettingsProvider` as the central static settings entry point.
- Added `ServiceRegistration` to centralize dependency registration.
- Kept `APIclient` as the shared RestSharp wrapper for API execution.

### API Layer
- Retained the request builder pattern in `RequestBuilder`.
- Retained shared validations in `ResponseValidators`.
- Kept API models for auth, booking, login, registration, and update flows.
- Preserved API services for auth, booking, and account-related endpoints.

### Test Data
- Kept JSON-based test data under `Utilities/TestData/API`.
- Kept `TestDataLoader` for loading JSON into strongly typed models.

### Logging and Reporting
- Added `ITestLogger` as the logging contract.
- Added `FileTestLogger` as a basic logger implementation.
- Added `ReportWriter` as a minimal report artifact writer.

### UI Skeleton
- Added `DriverFactory` for browser creation.
- Added `BasePage` as the shared page abstraction.
- Added `LoginPage` as a starter page object.
- Added `LoginFlow` as a business-flow wrapper.

### Database Skeleton
- Added `IDbHelper` and `DbHelper` as the DB access abstraction.
- Added `BookingRepository` as a starter repository.

### Test Structure
- Kept API tests for auth and booking flows.
- Added starter UI, DB, smoke, regression, and E2E scaffold tests so the folder structure is no longer empty.
- Cleaned duplicate booking workflow noise and improved category grouping.

### Documentation
- Added this README section to explain the framework baseline and what was completed in Phase 0.

## Phase 0 Summary
Phase 0 is the baseline scaffolding phase.
It is intended to prove:
- the framework has a clear structure
- API automation is working as the current executable baseline
- UI, DB, logging, and reporting layers have starter architecture
- the framework is organized for future Phase 1 expansion

## Phase 1 Work Items
Phase 1 should turn the scaffold into real execution capability.

### UI Automation
- Implement real locators in page objects.
- Build a working login flow and first stable smoke test.
- Add explicit waits and reusable UI helper methods.
- Add cross-browser execution support through the driver factory.

### Database Validation
- Implement a real DB provider inside `DbHelper`.
- Add parameterized SQL execution.
- Add UI to DB and API to DB validation methods.
- Add cleanup and data integrity checks.

### Reporting and Logging
- Replace console-heavy logging with structured file output.
- Add test run summaries.
- Add request/response attachment support.
- Add failure artifact capture.

### DI and Framework Wiring
- Expand dependency injection beyond the current starter registration.
- Register services, logger, DB helper, and browser context in a clean startup path.
- Move more framework creation logic out of tests and into shared factories.

### Test Coverage Expansion
- Add real smoke tests for UI, API, and E2E flows.
- Add negative and boundary scenarios for API endpoints.
- Add regression coverage for stable business workflows.
- Add data-driven coverage where the same scenario needs multiple inputs.

### Test Data Management
- Add builder/factory classes for unique and boundary data.
- Reduce reliance on static JSON for all scenarios.
- Add test data cleanup and reuse strategy.

### CI/CD Readiness
- Add build and test execution instructions for pipeline use.
- Separate smoke and regression execution paths.
- Add artifact publishing conventions for logs and reports.

## Phase 1 Priority Order
1. Real UI page objects and one smoke flow
2. Real DB helper and one validation query path
3. Structured logging and report output
4. DI cleanup and framework startup wiring
5. Expanded API negative and boundary coverage
6. Data factories and cleanup strategy
7. CI-friendly execution and artifact handling

## Phase 0 Scope
Phase 0 is the framework baseline:
- buildable project structure
- centralized config entry point
- reusable API client and request builders
- starter UI, DB, logging, and reporting scaffolds
- baseline API smoke and negative tests

## Deferred to Phase 1
- full UI automation coverage
- real database execution provider
- richer reporting and screenshots
- parallel execution hardening
