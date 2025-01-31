// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.StackHCI
{
    /// <summary> A class representing collection of ArcSetting and their operations over its parent. </summary>
    public partial class ArcSettingCollection : ArmCollection, IEnumerable<ArcSetting>, IAsyncEnumerable<ArcSetting>
    {
        private readonly ClientDiagnostics _arcSettingClientDiagnostics;
        private readonly ArcSettingsRestOperations _arcSettingRestClient;

        /// <summary> Initializes a new instance of the <see cref="ArcSettingCollection"/> class for mocking. </summary>
        protected ArcSettingCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ArcSettingCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ArcSettingCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _arcSettingClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.StackHCI", ArcSetting.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ArcSetting.ResourceType, out string arcSettingApiVersion);
            _arcSettingRestClient = new ArcSettingsRestOperations(_arcSettingClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, arcSettingApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != HciCluster.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, HciCluster.ResourceType), nameof(id));
        }

        /// <summary> Create ArcSetting for HCI cluster. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="arcSetting"> Parameters supplied to the Create ArcSetting resource for this HCI cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> or <paramref name="arcSetting"/> is null. </exception>
        public async virtual Task<ArmOperation<ArcSetting>> CreateOrUpdateAsync(bool waitForCompletion, string arcSettingName, ArcSettingData arcSetting, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));
            if (arcSetting == null)
            {
                throw new ArgumentNullException(nameof(arcSetting));
            }

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _arcSettingRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, arcSettingName, arcSetting, cancellationToken).ConfigureAwait(false);
                var operation = new StackHCIArmOperation<ArcSetting>(Response.FromValue(new ArcSetting(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create ArcSetting for HCI cluster. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="arcSetting"> Parameters supplied to the Create ArcSetting resource for this HCI cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> or <paramref name="arcSetting"/> is null. </exception>
        public virtual ArmOperation<ArcSetting> CreateOrUpdate(bool waitForCompletion, string arcSettingName, ArcSettingData arcSetting, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));
            if (arcSetting == null)
            {
                throw new ArgumentNullException(nameof(arcSetting));
            }

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _arcSettingRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, arcSettingName, arcSetting, cancellationToken);
                var operation = new StackHCIArmOperation<ArcSetting>(Response.FromValue(new ArcSetting(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get ArcSetting resource details of HCI Cluster. </summary>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> is null. </exception>
        public async virtual Task<Response<ArcSetting>> GetAsync(string arcSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.Get");
            scope.Start();
            try
            {
                var response = await _arcSettingRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, arcSettingName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _arcSettingClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ArcSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get ArcSetting resource details of HCI Cluster. </summary>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> is null. </exception>
        public virtual Response<ArcSetting> Get(string arcSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.Get");
            scope.Start();
            try
            {
                var response = _arcSettingRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, arcSettingName, cancellationToken);
                if (response.Value == null)
                    throw _arcSettingClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ArcSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get ArcSetting resources of HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ArcSetting" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ArcSetting> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ArcSetting>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _arcSettingRestClient.ListByClusterAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ArcSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ArcSetting>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _arcSettingRestClient.ListByClusterNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ArcSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get ArcSetting resources of HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ArcSetting" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ArcSetting> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ArcSetting> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _arcSettingRestClient.ListByCluster(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ArcSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ArcSetting> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _arcSettingRestClient.ListByClusterNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ArcSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string arcSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(arcSettingName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> is null. </exception>
        public virtual Response<bool> Exists(string arcSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(arcSettingName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> is null. </exception>
        public async virtual Task<Response<ArcSetting>> GetIfExistsAsync(string arcSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _arcSettingRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, arcSettingName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ArcSetting>(null, response.GetRawResponse());
                return Response.FromValue(new ArcSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="arcSettingName"> The name of the proxy resource holding details of HCI ArcSetting information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="arcSettingName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="arcSettingName"/> is null. </exception>
        public virtual Response<ArcSetting> GetIfExists(string arcSettingName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(arcSettingName, nameof(arcSettingName));

            using var scope = _arcSettingClientDiagnostics.CreateScope("ArcSettingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _arcSettingRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, arcSettingName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ArcSetting>(null, response.GetRawResponse());
                return Response.FromValue(new ArcSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ArcSetting> IEnumerable<ArcSetting>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ArcSetting> IAsyncEnumerable<ArcSetting>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
