﻿using FxiaokeSDK.Request;
using FxiaokeSDK.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace FxiaokeSDK
{
    public class FxiaokeClient : FxiaokeClientBase
    {
        #region 授权/身份验证

        public ApiResult<CorpAccessTokenGetResponse> Execute(CorpAccessTokenGetRequest request)
        {
            return Execute<CorpAccessTokenGetRequest, CorpAccessTokenGetResponse>("/cgi/corpAccessToken/get/V2", request);
        }

        public ApiResult<AppAccessTokenGetResponse> Execute(AppAccessTokenGetRequest request)
        {
            return Execute<AppAccessTokenGetRequest, AppAccessTokenGetResponse>("/cgi/appAccessToken/get", request);
        }

        public ApiResult<JsApiTicketGetResponse> Execute(JsApiTicketGetRequest request)
        {
            return Execute<JsApiTicketGetRequest, JsApiTicketGetResponse>("/cgi/jsApiTicket/get", request);
        }

        public ApiResult<BaseResponse> Execute(Oauth2AccountBindRequest request)
        {
            return Execute<Oauth2AccountBindRequest, BaseResponse>("/oauth2/accountBind", request);
        }

        public ApiResult<Oauth2OpenUserIdGetRespnose> Execute(Oauth2OpenUserIdGetRequest request)
        {
            return Execute<Oauth2OpenUserIdGetRequest, Oauth2OpenUserIdGetRespnose>("/oauth2/openUserId/get", request);
        }

        public ApiResult<UnidGetResponse> Execute(UnidGetRequest request)
        {
            return Execute<UnidGetRequest, UnidGetResponse>("/cgi/unid/get", request);
        }

        public ApiResult<UnidBatchGetResponse> Execute(UnidBatchGetRequest request)
        {
            return Execute<UnidBatchGetRequest, UnidBatchGetResponse>("/cgi/unid/batch/get", request);
        }

        public ApiResult<OpenIdGetResponse> Execute(OpenIdGetRequest request)
        {
            return Execute<OpenIdGetRequest, OpenIdGetResponse>("/cgi/openId/get", request);
        }

        public ApiResult<OpenIdBatchGetResponse> Execute(OpenIdBatchGetRequest request)
        {
            return Execute<OpenIdBatchGetRequest, OpenIdBatchGetResponse>("/cgi/openId/batch/get", request);
        }

        #endregion


        #region 通讯录管理 - 获取部门列表

        public ApiResult<DepartmentListResponse> Execute(BaseCgiRequest request)
        {
            return Execute<BaseCgiRequest, DepartmentListResponse>("/cgi/department/list", request);
        }

        public ApiResult<UserSimpleListResponse> Execute(UserSimpleListRequest request)
        {
            return Execute<UserSimpleListRequest, UserSimpleListResponse>("/cgi/user/simpleList", request);
        }

        public ApiResult<UserGetResponse> Execute(UserGetRequest request)
        {
            return Execute<UserGetRequest, UserGetResponse>("/cgi/user/get", request);
        }
        public ApiResult<UserListResponse> Execute(UserListRequest request)
        {
            return Execute<UserListRequest, UserListResponse>("/cgi/user/list", request);
        }

        public ApiResult<DepartmentDetailResponse> Execute(DepartmentDetailRequest request)
        {
            return Execute<DepartmentDetailRequest, DepartmentDetailResponse>("/cgi/department/detail", request);
        }

        #endregion


        #region CRM业务接口

        public ApiResult<BaseResponse> Execute(CrmTeamAddRequest request)
        {
            return Execute<CrmTeamAddRequest, BaseResponse>("/cgi/crm/team/add", request);
        }

        public ApiResult<CrmTeamGetResponse> Execute(CrmTeamGetRequest request)
        {
            return Execute<CrmTeamGetRequest, CrmTeamGetResponse>("/cgi/crm/team/get", request);
        }

        public ApiResult<BaseResponse> Execute(CrmTeamDeleteRequest request)
        {
            return Execute<CrmTeamDeleteRequest, BaseResponse>("/cgi/crm/team/delete", request);
        }

        public ApiResult<BaseResponse> Excute(CrmAccountReturnRequest request)
        {
            return Execute<CrmAccountReturnRequest, BaseResponse>("/cgi/crm/data/account/return", request);
        }

        public ApiResult<BaseResponse> Excute(CrmDataChangeSalesStageRequest request)
        {
            return Execute<CrmDataChangeSalesStageRequest, BaseResponse>("/cgi/crm/data/changeSalesStage", request);
        }


        #endregion


        #region CRM - CRM基础接口

        public ApiResult<CrmCountryAreaOptionsGetResponse> Execute(CrmCountryAreaOptionsGetRequest request)
        {
            return Execute<CrmCountryAreaOptionsGetRequest, CrmCountryAreaOptionsGetResponse>("/cgi/crm/countryAreaOptions/get", request);
        }

        public ApiResult<CrmQueryAreaResponse> Execute(CrmQueryAreaRequest request)
        {
            return Execute<CrmQueryAreaRequest, CrmQueryAreaResponse>("/cgi/crm/countryAreaOptions/get", request);
        }

        #endregion


        #region CRM - CRM基础接口V2

        public ApiResult<CrmObjectDescribeV2Response> Execute(CrmObjectDescribeV2Request request)
        {
            return Execute<CrmObjectDescribeV2Request, CrmObjectDescribeV2Response>("/cgi/crm/v2/object/describe", request);
        }

        public ApiResult<CrmObjectListV2Response> Execute(CrmObjectListV2Request request)
        {
            return Execute<CrmObjectListV2Request, CrmObjectListV2Response>("/cgi/crm/v2/object/list", request);
        }

        public ApiResult<CrmDataCreateV2Response> Execute(CrmDataCreateV2Request request)
        {
            return Execute<CrmDataCreateV2Request, CrmDataCreateV2Response>("/cgi/crm/v2/data/create", request);
        }

        public ApiResult<BaseResponse> Execute(CrmDataUpdateV2Request request)
        {
            return Execute<CrmDataUpdateV2Request, BaseResponse>("/cgi/crm/v2/data/update", request);
        }

        public ApiResult<CrmDataQueryV2Response> Execute(CrmDataQueryV2Request request)
        {
            return Execute<CrmDataQueryV2Request, CrmDataQueryV2Response>("/cgi/crm/v2/data/query", request);
        }

        public ApiResult<CrmDataGetV2Response> Execute(CrmDataGetV2Request request)
        {
            return Execute<CrmDataGetV2Request, CrmDataGetV2Response>("/cgi/crm/v2/data/get", request);
        }

        public ApiResult<BaseResponse> Execute(CrmDataInvalidV2Request request)
        {
            return Execute<CrmDataInvalidV2Request, BaseResponse>("/cgi/crm/v2/data/invalid", request);
        }

        public ApiResult<BaseResponse> Execute(CrmDataRecoverV2Request request)
        {
            return Execute<CrmDataRecoverV2Request, BaseResponse>("/cgi/crm/v2/data/recover", request);
        }

        public ApiResult<BaseResponse> Execute(CrmDataDeleteV2Request request)
        {
            return Execute<CrmDataDeleteV2Request, BaseResponse>("/cgi/crm/v2/data/delete", request);
        }

        public ApiResult<BaseResponse> Execute(CrmDataChangeOwnerV2Request request)
        {
            return Execute<CrmDataChangeOwnerV2Request, BaseResponse>("/cgi/crm/v2/data/changeOwner", request);
        }

        #endregion


        #region CRM - CRM对象接口V2(自定义对象)

        public ApiResult<CrmCustomDataCreateV2Response> Execute(CrmCustomDataCreateV2Request request)
        {
            return Execute<CrmCustomDataCreateV2Request, CrmCustomDataCreateV2Response>("/cgi/crm/custom/data/create", request);
        }

        public ApiResult<BaseResponse> Execute(CrmCustomDataUpdateV2Request request)
        {
            return Execute<CrmCustomDataUpdateV2Request, BaseResponse>("/cgi/crm/custom/data/update", request);
        }

        public ApiResult<CrmCustomDataQueryV2Response> Execute(CrmCustomDataQueryV2Request request)
        {
            return Execute<CrmCustomDataQueryV2Request, CrmCustomDataQueryV2Response>("/cgi/crm/custom/data/query", request);
        }

        public ApiResult<CrmCustomDataGetV2Response> Execute(CrmCustomDataGetV2Request request)
        {
            return Execute<CrmCustomDataGetV2Request, CrmCustomDataGetV2Response>("/cgi/crm/custom/data/get", request);
        }

        public ApiResult<BaseResponse> Execute(CrmCustomDataInvalidV2Request request)
        {
            return Execute<CrmCustomDataInvalidV2Request, BaseResponse>("/cgi/crm/custom/data/invalid", request);
        }

        public ApiResult<BaseResponse> Execute(CrmCustomDataRecoverV2Request request)
        {
            return Execute<CrmCustomDataRecoverV2Request, BaseResponse>("/cgi/crm/custom/data/recover", request);
        }

        public ApiResult<BaseResponse> Execute(CrmCustomDataDeleteV2Request request)
        {
            return Execute<CrmCustomDataDeleteV2Request, BaseResponse>("/cgi/crm/custom/data/delete", request);
        }

        public ApiResult<BaseResponse> Execute(CrmCustomDataChangeOwnerV2Request request)
        {
            return Execute<CrmCustomDataChangeOwnerV2Request, BaseResponse>("/cgi/crm/custom/data/changeOwner", request);
        }

        #endregion


        #region 审批流程接口

        public ApiResult<CrmObjectApprovalInstancesQueryResponse> Execute(CrmObjectApprovalInstancesQueryRequest request)
        {
            return Execute<CrmObjectApprovalInstancesQueryRequest, CrmObjectApprovalInstancesQueryResponse>("/cgi/crm/object/approvalInstances/query", request);
        }

        public ApiResult<CrmApprovalInstanceGetResponse> Execute(CrmApprovalInstanceGetRequest request)
        {
            return Execute<CrmApprovalInstanceGetRequest, CrmApprovalInstanceGetResponse>("/cgi/crm/approvalInstance/get", request);
        }

        public ApiResult<BaseResponse> Execute(CrmApprovalTaskActionRequest request)
        {
            return Execute<CrmApprovalTaskActionRequest, BaseResponse>("/cgi/crm/approvalTask/action", request);
        }

        public ApiResult<CrmApprovalInstancesQueryResponse> Execute(CrmApprovalInstancesQueryRequest request)
        {
            return Execute<CrmApprovalInstancesQueryRequest, CrmApprovalInstancesQueryResponse>("/cgi/crm/approvalInstances/query", request);
        }

        #endregion


        #region 发送消息

        public ApiResult<BaseResponse> Execute(MessageSendRequest request)
        {
            return Execute<MessageSendRequest, BaseResponse>("/cgi/message/send", request);
        }

        public ApiResult<BaseResponse> Execute(AppMessageSendRequest request)
        {
            return Execute<AppMessageSendRequest, BaseResponse>("/cgi/app/message/send", request);
        }

        #endregion


        #region 素材管理

        public Task<ApiResult<MediaUploadResponse>> Execute(MediaUploadRequest request)
        {
            return Upload<MediaUploadRequest, MediaUploadResponse>(request);
        }

        public ApiResult<Stream> Execute(MediaDownloadRequest request)
        {
            return Download("/media/download", request);
        }

        public ApiResult<BaseResponse> Execute(MediaDeleteRequest request)
        {
            return Execute<MediaDeleteRequest, BaseResponse>("/media/delete", request);
        }

        #endregion
    }
}
