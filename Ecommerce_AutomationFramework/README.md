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
