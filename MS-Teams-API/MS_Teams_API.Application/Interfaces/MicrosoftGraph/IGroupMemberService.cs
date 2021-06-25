using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Graph;

namespace MS_Teams_API.Application.Interfaces.MicrosoftGraph
{
    class IGroupMemberService
    {
    }
}
// <copyright file="IGroupMembersService.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace TProd.Portal.Api.Application.Interfaces.MicrosoftGraph
{
    using Microsoft.Graph;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Group Members Service.
    /// </summary>
    public interface IGroupMembersService
    {
        /// <summary>
        /// get group members page by id.
        /// </summary>
        /// <param name="groupId">group id.</param>
        /// <returns>group members page.</returns>
        Task<IGroupTransitiveMembersCollectionWithReferencesPage> GetGroupMembersPageByIdAsync(string groupId);

        /// <summary>
        /// get group members page by next page ur;.
        /// </summary>
        /// <param name="groupMembersRef">group members page reference.</param>
        /// <param name="nextPageUrl">group members next page data link url.</param>
        /// <returns>group members page.</returns>
        Task<IGroupTransitiveMembersCollectionWithReferencesPage> GetGroupMembersNextPageAsnyc(IGroupTransitiveMembersCollectionWithReferencesPage groupMembersRef, string nextPageUrl);
    }
}
