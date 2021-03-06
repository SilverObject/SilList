﻿CREATE TABLE [data].[Business] (
    [businessId]          UNIQUEIDENTIFIER CONSTRAINT [DF_Business_businessId] DEFAULT (newid()) NOT NULL,
    [name]                NVARCHAR (250)   NOT NULL,
    [summary]             NVARCHAR (MAX)   NULL,
    [description]         NVARCHAR (MAX)   NULL,
    [address]             NVARCHAR (MAX)   NULL,
    [cityTypeId]          INT              NULL,
    [stateTypeId]         INT              NULL,
    [countryTypeId]       INT              NULL,
    [zip]                 INT              NULL,
    [phone]               NVARCHAR (50)    NULL,
    [fax]                 NVARCHAR (50)    NULL,
    [url]                 NVARCHAR (50)    NULL,
    [startDate]           DATE             NOT NULL,
    [endDate]             DATE             NOT NULL,
    [listingStatusTypeId] INT              CONSTRAINT [DF__tmp_ms_xx__isApp__436BFEE3] DEFAULT ((1)) NULL,
    [createdBy]           INT              NULL,
    [modifiedBy]          INT              NULL,
    [modified]            DATETIME         CONSTRAINT [DF_Business_modified] DEFAULT (getdate()) NOT NULL,
    [created]             DATETIME         CONSTRAINT [DF_Business_created] DEFAULT (getdate()) NOT NULL,
    [isActive]            BIT              CONSTRAINT [DF_Business_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Business] PRIMARY KEY CLUSTERED ([businessId] ASC),
    CONSTRAINT [FK_Business_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Business_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Business_EntryStatusType] FOREIGN KEY ([listingStatusTypeId]) REFERENCES [app].[ListingStatusType] ([listingStatusTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Business_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);

























